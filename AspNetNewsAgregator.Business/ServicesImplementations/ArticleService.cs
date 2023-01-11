using AspNetNewsAgregator.Core.DataTransferObjects;
using AspNetNewsAgregator.Core.Abstractions;
using AspNetNewsAgregator.Core;

namespace AspNetNewsAgregator.Business.ServicesImplementations
{
    public class ArticleService : IArticleService
    {
        private readonly ArticlesStorage _articlesStorage;

        public ArticleService(ArticlesStorage articlesStorage)
        {
            _articlesStorage = articlesStorage;
        }

        public async Task<List<ArticleDto>> GetArticlesByPageNumberAndPageSizeAsync(int pageNumber, int pageSize)
        {
            List<ArticleDto> list;
            //using(var db = new Context)
            //{
            //    list = db.Articles.AsNoTracking.Skip(page)
            //        .Take(page)
            //        .Select(art => new ArticleModel()
            //        {
            //            Id = art.Id,
            //        })
            //        .ToList();
            //}

            list = _articlesStorage.ArticlesList.Skip(pageNumber * pageSize).Take(pageSize).ToList();

            return list;
        }

        public async Task<List<ArticleDto>> GetNewArticlesFromExternalSourcesAsync()
        {
            var list = new List<ArticleDto>();

            return list;
        }

    }
}
