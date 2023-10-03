using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    [Table("Comment")]
    public class Comment
    {
        [Key]
        public int cmt_id { get; set; }

        public string captions { get; set; }


        [ForeignKey("UserNav")]
        public string comment_user_id { get; set; }
      

        [ForeignKey("PostNav")]
        public int post_id { get; set; }



        #region Foriegn Keys
        public LLUser UserNav { get; set; }
        public Post PostNav { get; set; }
        #endregion




    }
}
