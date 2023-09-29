
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Intrinsics.X86;


namespace BOL
{
    [Table("Post")]
    public class Post
    {
        [Key]
        public int Pid { get; set; }

        [Required]
        public string? Description { get; set; }

        
        [ForeignKey("UserNav")]
        public string Id { get; set; }
        public LLUser UserNav { get; set; }

    }
}
