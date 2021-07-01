using SOLID_Exercise.Appenders;
using SOLID_Exercise.Core.Factories;
using SOLID_Exercise.Enums;
using SOLID_Exercise.Layouts;
using SOLID_Exercise.Loggers;
using System;

namespace SOLID_Exercise.Core
{
    public class Engine : IEngine
    {
        private readonly ILayoutFactory layoutFactory;
        private readonly IAppenderFactory appenderFactory;

        private ILogger logger;

        public Engine(IAppenderFactory appenderFactory, ILayoutFactory layoutFactory)
        {
            this.appenderFactory = appenderFactory;
            this.layoutFactory = layoutFactory;
        }

        public void Run()
        {
            //Problem 01
            //ILayout simpleLayout = new SimpleLayout();
            //IAppender consoleAppender = new FileAppender(simpleLayout);
            //ILogger logger = new Logger(consoleAppender);

            //logger.Error("3/26/2015 2:08:11 PM", "Error parsing JSON.");
            //logger.Info("3/26/2015 2:08:11 PM", "User Pesho successfully registered.");


            //Problem 02
            //var simpleLayout = new SimpleLayout();
            //var consoleAppender = new ConsoleAppender(simpleLayout);

            //var file = new LogFile();
            //var fileAppender = new FileAppender(simpleLayout, file);

            //var logger = new Logger(consoleAppender, fileAppender);
            //logger.Error("3/26/2015 2:08:11 PM", "Error parsing JSON.");
            //logger.Info("3/26/2015 2:08:11 PM", "User Pesho successfully registered.");

            //Problem 03
            //var xmlLayout = new XmlLayout();
            //var consoleAppender = new ConsoleAppender(xmlLayout);
            //var logger = new Logger(consoleAppender);

            //logger.Fatal("3/31/2015 5:23:54 PM", "mscorlib.dll does not respond");
            //logger.Critical("3/31/2015 5:23:54 PM", "No connection string found in App.config");

            //Problem 04
            //var simpleLayout = new JsonLayout();
            //var consoleAppender = new ConsoleAppender(simpleLayout);
            //consoleAppender.ReportLevel = ReportLevel.Error;

            //var logger = new Logger(consoleAppender);

            //logger.Info("3/31/2015 5:33:07 PM", "Everything seems fine");
            //logger.Warning("3/31/2015 5:33:07 PM", "Warning: ping is too high - disconnect imminent");
            //logger.Error("3/31/2015 5:33:07 PM", "Error parsing request");
            //logger.Critical("3/31/2015 5:33:07 PM", "No connection string found in App.config");
            //logger.Fatal("3/31/2015 5:33:07 PM", "mscorlib.dll does not respond");



            //Problem 05

            //Before layout factory

            //Dictionary<string, ILayout> layoutsByType = new Dictionary<string, ILayout>
            //{
            //    {nameof(SimpleLayout), new SimpleLayout() },
            //    {nameof(XmlLayout), new XmlLayout() },
            //    {nameof(JsonLayout), new JsonLayout() },
            //};


            int n = int.Parse(Console.ReadLine());
            IAppender[] appenders = ReadAppenders(n);

            logger = new Logger(appenders);

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "END")
                {
                    break;
                }

                string[] parts = line.Split('|', StringSplitOptions.RemoveEmptyEntries);

                ReportLevel reportLevel = Enum.Parse<ReportLevel>(parts[0], true);
                string date = parts[1];
                string message = parts[2];

                this.ProcessCommand(reportLevel, date, message);
            }

            Console.WriteLine("Logger Info:");

            Console.WriteLine(logger);
        }

        private void ProcessCommand(ReportLevel reportLevel, string date, string message)
        {
            switch (reportLevel)
            {
                case ReportLevel.Info:
                    this.logger.Info(date, message);
                    break;
                case ReportLevel.Warning:
                    this.logger.Warning(date, message);
                    break;
                case ReportLevel.Error:
                    this.logger.Error(date, message);
                    break;
                case ReportLevel.Critical:
                    this.logger.Critical(date, message);
                    break;
                case ReportLevel.Fatal:
                    this.logger.Fatal(date, message);
                    break;
                default:
                    break;
            }
        }

        private IAppender[] ReadAppenders(int n)
        {
            IAppender[] appenders = new Appender[n];

            for (int i = 0; i < n; i++)
            {
                string[] appenderParts = Console.ReadLine().Split();

                string appenderType = appenderParts[0];
                string layoutType = appenderParts[1];
                ReportLevel reportLevel = appenderParts.Length == 3
                    ? Enum.Parse<ReportLevel>(appenderParts[2], true)
                    : ReportLevel.Info;

                ILayout layout = layoutFactory.CreateLayout(layoutType);

                IAppender appender = appenderFactory.CreateAppender(appenderType, layout, reportLevel);

                appenders[i] = appender;
            }

            return appenders;
        }
    }
}
