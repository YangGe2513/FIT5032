namespace HomeFinder.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Property
    {
        public int Id { get; set; }

        [Required]
        public string Address { get; set; }

        public int NumberOfRooms { get; set; }

        public decimal Size { get; set; }

        public decimal Price { get; set; }

        [Required]
        public string UserId { get; set; }
    }
}
