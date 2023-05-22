using FootballZone.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace FootballZone.Api.Models.Articles
{
    public class Article
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string UserName { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? LastUpdated { get; set; }
    }
}
