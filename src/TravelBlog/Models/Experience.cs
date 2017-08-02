using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace TravelBlog.Models
{
    [Table("Experiences")]
    public class Experience
    {
        [Key]
        public int ExperienceId { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int LocationId { get; set; }
        public int PersonId { get; set; }
        public virtual Location Location { get; set; }
        public virtual Person Person { get; set; }
    }
}
