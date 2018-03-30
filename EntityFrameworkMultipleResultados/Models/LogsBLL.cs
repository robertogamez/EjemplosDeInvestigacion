using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkMultipleResultados.Models
{
    public class LogsBLL
    {
        public LogInfoEntity GetLogInfo()
        {
            var db = new LoggingEntities();
            LogInfoEntity logInfo = new LogInfoEntity();

            using (var connection = db.Database.Connection)
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = "EXEC dbo.EjemploMultipleResultados";

                using (var reader = command.ExecuteReader())
                {
                    var logs = ((IObjectContextAdapter)db)
                        .ObjectContext.Translate<LogEntity>(reader).ToList();

                    reader.NextResult();

                    var countLogs = ((IObjectContextAdapter)db)
                        .ObjectContext.Translate<LogCountEntity>(reader).FirstOrDefault();

                    logInfo.LogCount = countLogs;
                    logInfo.Logs = logs;
                }
            }

            return logInfo;
        }
    }
}
