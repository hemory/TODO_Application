using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TODO_Application
{
   public class Task
    {
        public int Id { get; set; }
        public string TaskItem { get; set; }
        private static int nextId;
        public Task()
        {
            Id = Interlocked.Increment(ref nextId);
        }

    }
}
