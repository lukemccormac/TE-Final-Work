using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechElevator.Web.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserImage { get; set; }
        public string PostImage { get; set; }
        public int Likes { get; set; }
        public bool HasBeenLiked { get; set; }
        public string Caption { get; set; }
    }
}
