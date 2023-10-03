using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    [Table("Follow")]
    public class Follow
    {


        public string FollowerId { get; set; }
        public string FolloweeId { get; set; }


        public LLUser Follower { get; set; }
        public LLUser Followee { get; set; }



        public DateTime FollowDate { get; set; }
    }
}
