﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MusicHub.Data.Models
{
    public class SongPerformer
    {
        [Required]
        public int SongId { get; set; }

        [Required]
        [ForeignKey(nameof(SongId))]
        public Song Song { get; set; }

        [Required]
        public int PerformerId { get; set; }

        [Required]
        [ForeignKey(nameof(PerformerId))]
        public Performer Performer { get; set; }
    }
}
