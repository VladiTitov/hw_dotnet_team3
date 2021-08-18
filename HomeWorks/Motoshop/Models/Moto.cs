using System;
using Motoshop.Attributes;

namespace Motoshop.Models
{
    public class Moto
    {
        [Guid]
        public Guid Id { get; set; }
        [MinYear(2000)]
        public DateTime MadeIN { get; set; }
        public int Odometer { get; set; }
        public string Model { get; set; }
        public string ImagePreview { get; set; }
    }
}
