using System;
using System.ComponentModel.DataAnnotations;

namespace Echenim.Nine.Util.Audit
{
    public class LogEntry
    {
        public Int64 LogEntryId { get; set; }

        [Display(Name = "Date")]
        public DateTime LogDate { get; set; }
        public string Logger { get; set; }

        [Display(Name = "Level")]
        public string LogLevel { get; set; }
        public string Thread { get; set; }

        [Display(Name = "Entity")]
        public string EntityFormalNamePlural { get; set; }

        [Display(Name = "Key")]
        public int EntityKeyValue { get; set; }

        [Display(Name = "User")]
        public string UserName { get; set; }
        public string Message { get; set; }
        public string Exception { get; set; }
    }
}