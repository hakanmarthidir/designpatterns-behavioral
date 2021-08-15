using System;

namespace chainofresponbility_pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            // 6- Client
            ElasticLogger elasticLogger = new ElasticLogger() { HandlerName="Elastic" };
            DatabaseLogger databaseLogger = new DatabaseLogger() { HandlerName= "Database"};
            LocalStorageLogger localStorageLogger = new LocalStorageLogger() { HandlerName="LocalStorage" };

            elasticLogger.SetNextStep(databaseLogger);
            databaseLogger.SetNextStep(localStorageLogger);
            localStorageLogger.SetNextStep(null);

            elasticLogger.Process(new Log() { Message = "execution problem.", Date=DateTime.Now });
                       
        }
    }

    //1
    public class Log
    {
        public string Message { get; set; }
        public DateTime Date { get; set; }
    }
    //2
    public interface ILogHandler
    {
        string HandlerName { get; set; }
        void SetNextStep(ILogHandler nextstep);
        void Process(Log log);
    }
    //3
    public class ElasticLogger : ILogHandler
    {
        public string HandlerName { get; set; }
        private ILogHandler _logHandler;       

        public void Process(Log log)
        {
            try
            {
                //send the log to elastic server
                //throw new Exception("Demo Exception...");
                Console.WriteLine("saved the log on elastic");
            }
            catch (Exception)
            {
                //if you have any error you can continue with the next step 
                
                if (this._logHandler != null)
                {
                    Console.WriteLine($"an error occured - next step {_logHandler.HandlerName}..");
                    this._logHandler.Process(log);
                }                
            }
        }

        public void SetNextStep(ILogHandler nextstep)
        {
            this._logHandler = nextstep;
        }
    }
    //4
    public class DatabaseLogger : ILogHandler
    {
        public string HandlerName { get; set; }
        private ILogHandler _logHandler;

        public void Process(Log log)
        {
            try
            {
                //send the log to database server
                //throw new Exception("Demo Exception...");
                Console.WriteLine("saved the log on database");
            }
            catch (Exception)
            {
               
                if (this._logHandler != null)
                {
                    Console.WriteLine($"an error occured - next step {_logHandler.HandlerName}..");
                    this._logHandler.Process(log);
                }
            }
        }

        public void SetNextStep(ILogHandler nextstep)
        {
            this._logHandler = nextstep;
        }
    }
    //5
    public class LocalStorageLogger : ILogHandler
    {
        public string HandlerName { get; set; }
        private ILogHandler _logHandler;

        public void Process(Log log)
        {
            try
            {
                //send the log to locals storage 
                Console.WriteLine("saved the log on local storage");
            }
            catch (Exception)
            {
               
                if (this._logHandler != null)
                {
                    Console.WriteLine($"an error occured - next step {_logHandler.HandlerName}..");
                    this._logHandler.Process(log);
                }
            }
        }

        public void SetNextStep(ILogHandler nextstep)
        {
            this._logHandler = nextstep;
        }
    }

}
