namespace DTOs.Models
{
    public class File
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public byte[] FileInputStream { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
