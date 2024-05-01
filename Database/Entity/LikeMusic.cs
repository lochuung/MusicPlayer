using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicPlayer.Database.Entity
{
    [Table("LikeMusic")]
    public class LikeMusic
    {
        public int Id { get; set; } // Primary Key

        [Required] public string MusicCode { get; set; }

        // Foreign Keys and Navigation Properties for User-LikePlaylist relationship
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}