using System.ComponentModel.DataAnnotations;

namespace vroom_server.Model
{
    public class Feedback
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Number { get; set; }
        public string Rego { get; set; }
        public string Branch { get; set; }
        public string Like { get; set; }
        public string NotLike { get; set; }
    }
}
