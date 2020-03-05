using System;
namespace aspnet_api {
    public class Todo {
        public Todo() {
        }

        public int Id { get; set; }
        public string Subject { get; set; }
        public DateTime? DueDate { get; set; }
        public string Description { get; set; }
        public bool Done { get; set; }
    }
}
