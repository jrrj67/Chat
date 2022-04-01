namespace Chat.API.Models
{
    public class Chat
    {
        public int Id { get; set; }
        public int ServiceCallCreatorId { get; set; }
        public int FieldTeamId { get; set; }
        public int BackofficeTeamId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime FinishedAt { get; set; }
        public int NoteId { get; set; }
        
        // Nav
        public List<Message> Messages { get; set; } = new();
    }

    public class Message
    {
        public int Id { get; set; }
        public int ChatId { get; set; }
        public DateTime CreatedAt { get; set; }
        public int SenderId { get; set; }
        public int RecipientId { get; set; }
        public int UserId { get; set; }
        public string Text { get; set; } = String.Empty;

        // Nav
        public Chat Chat { get; set; } = new();
        public List<Reading> Readings { get; set; } = new();
    }

    public class Reading
    {
        public int Id { get; set; }
        public int MessageId { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; }

        // Nav
        public Message Message { get; set; } = new();
    }

    // NoteId quando e por quem será preenchido?
    // Início/Fim Chat como vai ser?
    // UserId pode ser matrícula?
}
