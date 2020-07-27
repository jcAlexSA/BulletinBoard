using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulletinBoard.Models.Adverts
{
    public class AdvertResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublishDate { get; set; }
        public int UserId { get; set; }
    }
}