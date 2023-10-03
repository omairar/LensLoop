using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace BOL
{
    [Table("LLUser")]
    public class LLUser: IdentityUser //Microsoft.Extensions.Identity.Stores
    {
   

        public IEnumerable<Post>? Posts { get; set; }
      
        
        public IEnumerable<Comment>? Comments { get; set; }
   

        public ICollection<Follow> Followers { get; set; }
        public ICollection<Follow> Followees { get; set; }


    }
}