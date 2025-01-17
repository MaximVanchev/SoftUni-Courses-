﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MusicHub.Data.Models
{
    public class Writer
    {
        public Writer()
        {
            Songs = new HashSet<Song>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [MaxLength(20)]
        public string Pseudonym { get; set; }

        public ICollection<Song> Songs { get; set; }
    }
}
