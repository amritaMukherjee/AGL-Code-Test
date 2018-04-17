using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
namespace ProgramingTest.LoggingService
{
    public class Logger:ILogger
    {
        public void ErrorLogger(Exception ex)
        {
            var AppName = ConfigurationManager.AppSettings.Get("AppName");
            if (!EventLog.SourceExists(AppName))
                EventLog.CreateEventSource(AppName, "Application");
            System.Reflection.PropertyInfo[] properties = ex.GetType()
                        .GetProperties();
            IEnumerable<string> fields = properties
                 .Select(property => new {
                     Name = property.Name,
                     Value = property.GetValue(ex, null)
                 })
                 .Select(x => String.Format(
                     "{0} = {1}",
                     x.Name,
                     x.Value != null ? x.Value.ToString() : String.Empty
                 ));
            EventLog.WriteEntry(AppName, ex.Message, EventLogEntryType.Error, 120, Convert.ToByte(String.Join("\n", fields)));
        }
    }
}