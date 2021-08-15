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
   

}
