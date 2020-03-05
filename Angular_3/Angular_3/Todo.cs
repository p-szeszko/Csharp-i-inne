using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Angular_3
{
    public class Todo
    {
        public Todo()
        {

        }
        public int Id { get; set; }
        public string Subject { get; set; }
        public DateTime? DueDate { get; set; }
        public string Description { get; set; }
        public bool Done { get; set; }

      /*  public Todo(int Id, string Subject, DateTime? DueData, string Description, bool Done)
        {
            this.Id = Id;
            this.Subject = Subject;
            this.DueDate = DueDate;
            this.Description = Description;
            this.Done = Done;
        }*/
    }
}
