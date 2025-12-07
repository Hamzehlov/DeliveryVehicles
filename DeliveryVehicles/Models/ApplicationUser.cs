using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace DeliveryVehicles.Models
{
    public class ApplicationUser: IdentityUser
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(20)]
        public string? Phone { get; set; }

        public DateTime? EmailVerifiedAt { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // حقول OTP الجديدة
        [MaxLength(6)]
        public string? OTPCode { get; set; }

        public DateTime? OTPExpiry { get; set; }

        public int OTPAttempts { get; set; }

        public DateTime? OTPGeneratedAt { get; set; }

        // خاصية محسوبة
        public string FullName => $"{FirstName} {LastName}";
    }
}
