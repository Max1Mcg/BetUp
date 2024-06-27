namespace BetUp.Logger.Interfaces
{
    public interface ILoggerActions
    {
        void LogOperation(string operation, string schemaName, Guid Id);
    }
}
