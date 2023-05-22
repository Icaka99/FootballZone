//Front End Models
using FEM = FootballZone.Api.Models.Articles;
//Back End Models
using BEM = FootballZone.Data.Models;

namespace FootballZone.Api.Mappers
{
    public static class ArticleMapper
    {
        public static BEM.Article MapAddArticle(FEM.AddArticle input, string userId)
        {
            return new BEM.Article
            {
                Title = input.Title,
                Content = input.Content,
                UserId = userId
            };
        }

        public static BEM.Article MapUpdateArticle(FEM.UpdateArticle input)
        {
            return new BEM.Article
            {
                Title = input.Title,
                Content = input.Content
            };
        }

        public static FEM.Article MapGetArticleById(BEM.Article dbArticle)
        {
            return new FEM.Article
            {
                Id = dbArticle.Id,
                Title = dbArticle.Title,
                Content = dbArticle.Content,
                UserName = dbArticle.User.UserName,
                CreatedOn = dbArticle.CreatedOn,
                LastUpdated = dbArticle.ModifiedOn
            };
        }

        public static List<FEM.Article> MapGetAllArticles(IEnumerable<BEM.Article> dbArticles)
        {
            var articles = new List<FEM.Article>();

            foreach (var dbArticle in dbArticles)
            {
                var article = new FEM.Article
                {
                    Id = dbArticle.Id,
                    Content = dbArticle.Content,
                    Title = dbArticle.Title,
                    UserName = dbArticle.User.UserName,
                    CreatedOn = dbArticle.CreatedOn,
                    LastUpdated = dbArticle.ModifiedOn
                };

                articles.Add(article);
            }

            return articles;
        }
    }
}
