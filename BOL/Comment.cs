using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class Comment
    {
        [Key]
        public int Cid { get; set; }

        public string Cmt { get; set; }

        [ForeignKey("UserNav")]
        public string Id { get; set; }
        public LLUser UserNav { get; set; }

        [ForeignKey("PostNav")]
        public int Pid { get; set; }
        public Post PostNav { get; set; }
    }
}
