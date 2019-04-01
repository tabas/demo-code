using Microsoft.Extensions.Logging;

namespace NovaXSoft.API.DataAccess.DataContext
{
    public class TraceLoggerProvider : ILoggerProvider
    {
        public ILogger CreateLogger(string categoryName) => new TraceLogger(categoryName);

        public void Dispose() { }
    }
}
