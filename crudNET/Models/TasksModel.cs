using crudNET.Enums;

namespace crudNET.Models
{
    public class TasksModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public StatusTasks Status { get; set; }
    }
}
