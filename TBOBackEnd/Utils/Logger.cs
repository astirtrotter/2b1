using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml;

namespace TBOBackEnd.Utils
{
  public static class Logger
  {
    private static readonly string LOG_CONFIG_FILE = @"log4net.config";

    private static readonly ILog _log = GetLogger(typeof(Logger));

    private static bool wasConfig = false;

    private static ILog GetLogger(Type type)
    {
      return LogManager.GetLogger(type);
    }

    private static void SetLog4NetConfiguration()
    {
      if (wasConfig) return;

      XmlDocument log4netConfig = new XmlDocument();
      log4netConfig.Load(File.OpenRead(Directory.GetCurrentDirectory() + "\\" + LOG_CONFIG_FILE));

      var repo = LogManager.CreateRepository(Assembly.GetEntryAssembly(), typeof(log4net.Repository.Hierarchy.Hierarchy));

      log4net.Config.XmlConfigurator.Configure(repo, log4netConfig["log4net"]);

      wasConfig = true;
    }

    public static void Debug(object message)
    {
      SetLog4NetConfiguration();
      _log.Debug(message);
    }

    public static void Warn(object message)
    {
      SetLog4NetConfiguration();
      _log.Warn(message);
    }

    public static void Error(object message)
    {
      SetLog4NetConfiguration();
      _log.Error(message);
    }
  }
}
