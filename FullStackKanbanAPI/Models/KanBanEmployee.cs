namespace FullStackKanbanAPI.Models
{
    public class KanBanEmployee // using this to add contents to the table we are using and what data should be inserted. 
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public long Phone{ get; set;}
    }
}
