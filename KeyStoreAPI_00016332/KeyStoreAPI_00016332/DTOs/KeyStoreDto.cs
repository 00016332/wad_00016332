namespace KeyStoreAPI_00016332.DTOs
{
    public class KeyStoreDto
    {
        public int Id { get; set; }
        public string KeyName { get; set; }
        public string KeyValue { get; set; }
        public DateTime createdAt { get; set; } = DateTime.Now;
        public int UserId { get; set; }

        public UserDto? User { get; set; }
    }
}
