using System.ComponentModel.DataAnnotations;

using FootballZone.Data.Common.Models;

namespace FootballZone.Data.Models
{
    public class Article : BaseDeletableModel<int>
    {
        public Article()
        {
        }

        [Required]
        [MaxLength(80)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
