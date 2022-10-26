﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieEntity.Models
{
    public class Movie
    {        
            [Key] //primary key

            [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //Autogenerated column
            public int Id { get; set; }
            public string Name { get; set; }
            public string MovieDesc { get; set; }
            public string MovieType { get; set; }
        
    }
}
