using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieEntity.Models
{
    public class ShowTimings
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Movie")]
        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        [ForeignKey("Theatre")]
        public int TheatreId { get; set; }
        public Theatre Theatre { get; set; }
        public DateTime ShowTime { get; set; }
    }
}
