using System.ComponentModel.DataAnnotations;

namespace KeyStoreAPI_00016332.Models
{
    public class KeyStore
    {
        public int Id { get; set; }
        [Required]
        public string KeyName { get; set; }
        [Required]
        public string KeyValue { get; set; }

        [Required]
        public DateTime createdAt {  get; set; } = DateTime.Now;
        [Required]
        public int UserId { get; set; }

        public User User { get; set; }
        
    }
}
