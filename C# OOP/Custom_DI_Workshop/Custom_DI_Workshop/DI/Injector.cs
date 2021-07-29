using Custom_DI_Workshop.DI.Attributes;
using Custom_DI_Workshop.DI.Containers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Custom_DI_Workshop.DI
{
    class Injector
    {
        private IContainer container;

        public Injector(IContainer container)
        {
            this.container = container;
        }

        public TClass Inject<TClass>()
        {
            if (!HasConstructorInjection<TClass>())
            {
                return (TClass)Activator.CreateInstance(typeof(TClass));

                //throw new ArgumentException("The class has no constructor, anotated with the inject attribute!");
            }

            return CreateConstructorInjection<TClass>();
        }


        private TClass CreateConstructorInjection<TClass>()
        {
            ConstructorInfo[] constructors = typeof(TClass).GetConstructors();

            foreach (var constructor in constructors)
            {
                if (constructor.GetCustomAttribute(typeof(Inject), true) == null)
                {
                    continue;
                }

                ParameterInfo[] constructorParams = constructor.GetParameters();
                object[] constructorParamObjects = new object[constructorParams.Length];
                int i = 0;

                //ILogger, IReader
                foreach (var paramInfo in constructorParams)
                {
                    Type interfaceType = paramInfo.ParameterType;
                    Type implementationType =  container.GetMapping(interfaceType);
                    object implementationInstance;

                    if (implementationType == null)
                    {
                        var implementationPair = container.GetCustomMapping(interfaceType);
                        implementationInstance = implementationPair.Value();
                    }
                    else
                    {
                        MethodInfo injectMethod = typeof(Injector).GetMethod("Inject");
                        injectMethod = injectMethod.MakeGenericMethod(implementationType);

                         implementationInstance = injectMethod.Invoke(this, new object[] { });
                    }

                    constructorParamObjects[i++] = implementationInstance;
                }
            
                return (TClass)Activator.CreateInstance(typeof(TClass), constructorParamObjects);
            }

            return default;
        }

        private bool HasConstructorInjection<TClass>()
        {
            return typeof(TClass).GetConstructors().Any(c => c.GetCustomAttributes(typeof(Inject), true).Any());
        }
    }
}
