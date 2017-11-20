using System;

namespace Watermark.Models
{
    public class Lifetime
    {
        public DateTime? Start { get; set; } = null;

        public DateTime? End { get; set; } = null;

        public TimeSpan? GetTotalDuration => Start != null && End != null ? End - Start : throw new InvalidOperationException("Liffetime Start or End time not set.");

        public bool HasBegun => Start != null ? DateTime.Now >= Start : throw new InvalidOperationException("Lifetime Start time has not been set.");

        public bool HasEnded => End != null ? DateTime.Now <= End : throw new InvalidOperationException("Lifetime End time has not been set.");

        public TimeSpan? Remaining => HasBegun && !HasEnded ? End - DateTime.Now : throw new InvalidOperationException("Lifetime has not begun, or has ended.");
    }
}