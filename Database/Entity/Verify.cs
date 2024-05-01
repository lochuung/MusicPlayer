using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicPlayer.Database.Entity
{
    [Table("Verifies")]
    public class Verify 
    {
        public int VerifyId { get; set; } // Primary Key

        [Required]
        public string Code { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [Required]
        public DateTime ExpiredDate { get; set; } = DateTime.Now.AddMinutes(5);

        // Foreign Key and Navigation Property for User-Verify relationship
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}