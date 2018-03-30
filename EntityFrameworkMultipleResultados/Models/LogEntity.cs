using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkMultipleResultados.Models
{
    public class LogEntity
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Thread { get; set; }
        public string Level { get; set; }
        public string Logger { get; set; }
        public string Message { get; set; }
        public string Exception { get; set; }
    }

    public class LogCountEntity
    {
        public int TotalLogs { get; set; }
    }

    public class LogInfoEntity
    {
        public List<LogEntity> Logs { get; set; }
        public LogCountEntity LogCount { get; set; }
    }
}
