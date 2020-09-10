namespace TodoApp
{
    internal class Todo
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public Todo(int id, string description)
        {
            Id = id;
            Description = description;
        }
    }
}
