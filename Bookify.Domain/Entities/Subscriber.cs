﻿namespace Bookify.Domain.Entities
{
    [Index(nameof(NationalId), IsUnique = true)]
    [Index(nameof(MobileNumber), IsUnique = true)]
    [Index(nameof(Email), IsUnique = true)]
    public class Subscriber : BaseEntity
    {
        public int Id { set; get; }
        [MaxLength(100)]
        public string FirstName { get; set; } = null!;

        [MaxLength(100)]
        public string LastName { get; set; } = null!;

        public DateTime DateOfBirth { get; set; }
        [MaxLength(20)]
        public string NationalId { get; set; } = null!;
        [MaxLength(15)]
        public string MobileNumber { get; set; } = null!;
        public bool HasWhatsApp { get; set; }


        [MaxLength(50)]
        public string Email { get; set; } = null!;
        [MaxLength(500)]
        public string ImageUrl { get; set; } = null!;

        [MaxLength(500)]
        public string ImageThumbnailUrl { get; set; } = null!;


        public int AreaId { get; set; }

        public Area? Area { get; set; }

        public int GovernorateId { get; set; }

        public Governorate? Governorate { get; set; }


        [MaxLength(500)]
        public string Address { get; set; } = null!;


        public bool Isblacklisted { get; set; }


        public ICollection<Subscription> Subscriptions { get; set; } = new List<Subscription>();
        public ICollection<Rental> Rentals { get; set; } = new List<Rental>();


    }
}
