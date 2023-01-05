using System.ComponentModel.DataAnnotations;

namespace vroom_server.Model
{
    public class Feedback
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public string VehicleNumber { get; set; }
        public string Branch { get; set; }
        public string Liked { get; set; }
        public string NotLiked { get; set; }
    }
}
