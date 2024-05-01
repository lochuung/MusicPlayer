using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicPlayer.Database.Entity
{
    [Table("Users")]
    public class User 
    {
        public int UserId { get; set; } // Primary key

        [Required] // Ensures non-null
        public string FullName { get; set; } 

        [Required]
        public DateTime Birthday { get; set; } 

        [Required]
        [EmailAddress] // Built-in validation for email format
        public string Email { get; set; } 
        
        // unique constraint
        [Required]
        [Phone] // Built-in validation for phone number format
        [MaxLength(10)]
        
        public string PhoneNumber { get; set; } 

        [Required]
        public string Password { get; set; }  

        // Navigation property for one-to-many relationship with Verify
        public virtual ICollection<Verify> Verifications { get; set; }
        
        // Navigation property for one-to-many relationship with LikePlaylist
        public virtual ICollection<LikePlaylist> LikePlaylists { get; set; }
    }

}