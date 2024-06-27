using BetUp.Logger.Interfaces;

namespace BetUp.Logger
{
    public class LoggerActions: ILoggerActions
    {
        ILogger<LoggerActions> _logger;
        public LoggerActions(ILogger<LoggerActions> logger) { _logger = logger; }
        public void LogOperation(string operation, string schemaName, Guid Id)
        {
            var logMessage = $"Операция {operation} в таблице {schemaName} для Id = {Id}";
            _logger.LogInformation(logMessage);
        }
    }
}
