using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using FootballZone.Api.Mappers;
using FootballZone.Api.Models.Articles;
using FootballZone.Data.Models;
using FootballZone.Services.Data;

//Front End Models
using FEM = FootballZone.Api.Models.Articles;
//Back End Models
using BEM = FootballZone.Data.Models;

namespace FootballZone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleService articleService;
        private readonly UserManager<ApplicationUser> userManager;

        public ArticlesController(IArticleService articleService, UserManager<ApplicationUser> userManager)
        {
            this.articleService = articleService;
            this.userManager = userManager;
        }

        [HttpPost]
        public async Task<ActionResult> Add(AddArticle input)
        {
            try
            {
                var user = await this.userManager.GetUserAsync(this.User);

                var article = ArticleMapper.MapAddArticle(input, user.Id);

                this.articleService.AddAsync(article);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch]
        public async Task<ActionResult<FEM.Article>> Update(UpdateArticle input)
        {
            try
            {
                var user = await this.userManager.GetUserAsync(this.User);

                var article = ArticleMapper.MapUpdateArticle(input);

                var updatedArticle = this.articleService.Update(article);

                return Ok(updatedArticle);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<FEM.Article>> GetAll()
        {
            try
            {
                var dbArticles = this.articleService.GetAll<BEM.Article>();

                var articles = ArticleMapper.MapGetAllArticles(dbArticles);

                return Ok(articles);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<ActionResult<FEM.Article>> GetById(string id)
        {
            try
            {
                var article = await this.articleService.GetByIdAsync(id);

                return Ok(article);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("{id}")]
        [HttpDelete]
        public ActionResult Delete(string id)
        {
            try
            {
                this.articleService.Delete(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}