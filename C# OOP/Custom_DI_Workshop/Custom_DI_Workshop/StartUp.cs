using Custom_DI_Workshop.Contracts;
using Custom_DI_Workshop.DI;
using Custom_DI_Workshop.DI.Containers;
using Custom_DI_Workshop.Loggers;
using System;

namespace Custom_DI_Workshop
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IContainer container = new SnakeGameContainer();
            container.ConfigureServices();
            Injector injector = new Injector(container);

            Engine engine = injector.Inject<Engine>();
            engine.Start();
            engine.End();
        }
    }
}
