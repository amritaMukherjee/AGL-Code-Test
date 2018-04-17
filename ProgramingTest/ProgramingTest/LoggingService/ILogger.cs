using System;
namespace ProgramingTest.LoggingService
{
    public interface ILogger
    {
          void ErrorLogger(Exception ex);
    }
}
