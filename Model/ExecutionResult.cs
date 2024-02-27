using System.ComponentModel.DataAnnotations;

namespace Flask_API_Development.Model
{
    public class ExecutionResult
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int TestCaseId { get; set; }
        public string Result { get; set; }
        public string Comments { get; set; }
        public TestCase TestCase { get; set; }
    }
}
