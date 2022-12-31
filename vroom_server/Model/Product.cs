using System.ComponentModel.DataAnnotations;

namespace vroom_server.Model
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductPrice { get; set; }
        public string Description { get; set; }

    }
}
