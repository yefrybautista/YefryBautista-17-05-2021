using System;
using System.Collections.Generic;
using System.Text;

namespace Bertoni.Entities.Models
{
    public class Album
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Photo> Photos { get; set; }

    }
}
