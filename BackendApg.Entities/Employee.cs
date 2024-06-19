namespace BackendApg.Entities
{
    public class Employee
    {
        public required string Id { get; set; }
        public required string Fullname { get; set; }
        public DateTime Birth { get; set; }
    }
}
