using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace BOL
{
    [Table("LLUser")]
    public class LLUser: IdentityUser //Microsoft.Extensions.Identity.Stores
    {
        public int? follower { get; set; }
        public int? following { get; set; }

        public IEnumerable<Post>? Posts { get; set; }

    }
}