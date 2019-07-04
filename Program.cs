using System;
using System.Reflection;
using System.IO;
using System.Xml;
using log4net.Config;

namespace IDK
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument log4netConfig = new XmlDocument();
            log4netConfig.Load(File.OpenRead(Directory.GetCurrentDirectory() + "/config/log4net.config"));

            var repo = log4net.LogManager.CreateRepository(Assembly.GetEntryAssembly(), typeof(log4net.Repository.Hierarchy.Hierarchy));
            XmlConfigurator.Configure(repo, log4netConfig["log4net"]);

            Emulator.Initialize();
            while(true) Console.ReadLine();
        }
    }
}
