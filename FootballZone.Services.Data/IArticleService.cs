using FootballZone.Data.Models;

namespace FootballZone.Services.Data
{
    public interface IArticleService
    {
        void AddAsync(Article article);

        Article Update(Article article);

        void Delete(string id);

        Task<Article> GetByIdAsync(string id);

        int GetCount();

        IEnumerable<Article> GetAll<T>();
    }
}
