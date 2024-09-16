using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskTracker
{
    public class Task
    {
        public int Id { get; set; }
        public string Description {get;set;} = string.Empty;
        public string Status {get; set;} = string.Empty;
        public DateTime CreatedAt = DateTime.Now;
        public DateTime UpdatedAt = DateTime.Now;   

    }
}