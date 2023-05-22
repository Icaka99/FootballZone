using FootballZone.Data.Common.Repositories;
using FootballZone.Data.Models;

namespace FootballZone.Services.Data
{
    public class ArticlesService : IArticleService
    {
        private readonly IDeletableEntityRepository<Article> articleRepository;

        public ArticlesService(IDeletableEntityRepository<Article> articleRepository)
        {
            this.articleRepository = articleRepository;
        }

        public async void AddAsync(Article article)
        {
            await this.articleRepository.AddAsync(article);
        }

        public Article Update(Article article)
        {
            return this.articleRepository.Update(article);
        }

        public void Delete(string id)
        {
            this.articleRepository.Delete(id);
        }

        public async Task<Article> GetByIdAsync(string id)
        {
            return await this.articleRepository.GetByIdWithDeletedAsync(id);
        }

        public int GetCount()
        {
            return this.articleRepository.AllAsNoTracking().Count();
        }

        public IEnumerable<Article> GetAll<T>()
        {
            return this.articleRepository.All().ToList();
        }
    }
}
