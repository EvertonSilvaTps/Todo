namespace Todo.API.Models
{
    public class TodoModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public bool IsCompleted { get; set; }

        public TodoModel(string title)
        {
            Id = Guid.NewGuid();
            Title = title;
            IsCompleted = false;
        }
    }
}
