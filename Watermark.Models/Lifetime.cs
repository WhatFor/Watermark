using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Watermark.Models
{
    public class Lifetime
    {
        [Key]
        public int Id { get; set; }

        public DateTime? Start { get; set; } = null;

        public DateTime? End { get; set; } = null;

        [NotMapped]
        public TimeSpan? GetTotalDuration => Start != null && End != null ? End - Start : throw new InvalidOperationException("Liffetime Start or End time not set.");

        [NotMapped]
        public bool HasBegun => Start != null ? DateTime.Now >= Start : throw new InvalidOperationException("Lifetime Start time has not been set.");

        [NotMapped]
        public bool HasEnded => End != null ? DateTime.Now <= End : throw new InvalidOperationException("Lifetime End time has not been set.");

        [NotMapped]
        public TimeSpan? Remaining => HasBegun && !HasEnded ? End - DateTime.Now : throw new InvalidOperationException("Lifetime has not begun, or has ended.");
    }
}