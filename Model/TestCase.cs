using System.ComponentModel.DataAnnotations;

namespace Flask_API_Development.Model
{
    public class TestCase
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public List<ExecutionResult> ExecutionResults { get; set; }
    }
 
}
