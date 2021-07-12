using System;
using System.Reflection;

namespace Reflection_and_Attributes_LAB
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeName = Console.ReadLine();

            MethodInfo[] methods = Type.GetType(typeName).GetMethods();

            Console.WriteLine("Methods:");

            foreach (var method in methods)
            {
                Console.WriteLine(method.Name);
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Interfaces:");

            Type[] interfaces = Type.GetType(typeName).GetInterfaces();

            foreach (var type in interfaces)
            {
                Console.WriteLine(type.FullName);
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("FieldsInfo, Atrributes");

            FieldInfo[] fields = Type.GetType(typeName).GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (var field in fields)
            {
                Console.WriteLine(field.Attributes);
                Console.WriteLine(field.IsPublic);


                //like this we can access private fields!!
                //var privateField = field.GetValue(classname); 
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Constructor info:");

            ConstructorInfo[] constructors = Type.GetType(typeName).GetConstructors();

            foreach (var constructor in constructors)
            {
                ParameterInfo[] parameterInfo = constructor.GetParameters();
                
                //ConstructorInfo concreteConstructor = type.GetConstructor( new Type[] { typeof(arg1.classname), typeof(arg2.classname) });
                
            }

            

        }
    }
}
