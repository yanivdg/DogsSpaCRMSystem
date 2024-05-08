namespace DogsSpaCRMSystem.Server.Model
{
    public class Appointment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Automatically set on creation
    }
}
