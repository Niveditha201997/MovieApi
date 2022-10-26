using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MovieEntity.Models
{
    public class Booking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Movie")]
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public string MovieName { get; set; }        
        public string TheatreName { get; set; }
        public int seatNo { get; set; }        
        public string Address { get; set; }
    }
}
