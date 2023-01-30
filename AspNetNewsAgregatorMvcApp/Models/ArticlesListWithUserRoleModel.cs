using AspNetNewsAgregator.Core.DataTransferObjects;

namespace AspNetNewsAgregatorMvcApp.Models;

public class ArticlesListWithUserRoleModel
{
    public List<ArticleDto> Articles { get; set; }
    public bool IsAdmin { get; set; }
}