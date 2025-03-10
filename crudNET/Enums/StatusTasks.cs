using System.ComponentModel;

namespace crudNET.Enums
{
    public enum StatusTasks
    {
        [Description("New Task")]
        New = 0,
        [Description("Task in progress")]
        Loading = 1,
        [Description("Finish Task")]
        Finish = 2,
    }
}