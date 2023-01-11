using AspNetNewsAgregator.Core.DataTransferObjects;

namespace AspNetNewsAgregator.Core
{
    public class ArticlesStorage
    {
        public readonly List<ArticleDto> ArticlesList;

        public ArticlesStorage()
        {
            ArticlesList = new List<ArticleDto>()
            {
            new ArticleDto()
            {
                Id = Guid.NewGuid(),
                Title = "Lorem ipsum dolor sit amet.",
                PublicationDate = DateTime.Now,
                Category = "News",
                ShortSummary = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus lorem nulla, sollicitudin vitae mi id, maximus ultricies ante. Nullam non ipsum tortor. Pellentesque eget tempor sapien. Donec semper nisi quis posuere laoreet. Nunc a magna sit amet justo blandit feugiat. Vestibulum commodo lectus odio, sit amet pellentesque nisl consectetur ac. Maecenas vestibulum placerat augue, a tempus velit interdum elementum. Duis eget libero et turpis sagittis egestas non quis nisl."
            },
            new ArticleDto()
            {
                Id = Guid.NewGuid(),
                Title = "Lorem ipsum dolor sit amet.",
                PublicationDate = DateTime.Now,
                Category = "News",
                ShortSummary = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus lorem nulla, sollicitudin vitae mi id, maximus ultricies ante. Nullam non ipsum tortor. Pellentesque eget tempor sapien. Donec semper nisi quis posuere laoreet. Nunc a magna sit amet justo blandit feugiat. Vestibulum commodo lectus odio, sit amet pellentesque nisl consectetur ac. Maecenas vestibulum placerat augue, a tempus velit interdum elementum. Duis eget libero et turpis sagittis egestas non quis nisl."
            },
            new ArticleDto()
            {
                Id = Guid.NewGuid(),
                Title = "Lorem ipsum dolor sit amet.",
                PublicationDate = DateTime.Now,
                Category = "News",
                ShortSummary = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus lorem nulla, sollicitudin vitae mi id, maximus ultricies ante. Nullam non ipsum tortor. Pellentesque eget tempor sapien. Donec semper nisi quis posuere laoreet. Nunc a magna sit amet justo blandit feugiat. Vestibulum commodo lectus odio, sit amet pellentesque nisl consectetur ac. Maecenas vestibulum placerat augue, a tempus velit interdum elementum. Duis eget libero et turpis sagittis egestas non quis nisl."
            },
            new ArticleDto()
            {
                Id = Guid.NewGuid(),
                Title = "Lorem ipsum dolor sit amet.",
                PublicationDate = DateTime.Now,
                Category = "News",
                ShortSummary = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus lorem nulla, sollicitudin vitae mi id, maximus ultricies ante. Nullam non ipsum tortor. Pellentesque eget tempor sapien. Donec semper nisi quis posuere laoreet. Nunc a magna sit amet justo blandit feugiat. Vestibulum commodo lectus odio, sit amet pellentesque nisl consectetur ac. Maecenas vestibulum placerat augue, a tempus velit interdum elementum. Duis eget libero et turpis sagittis egestas non quis nisl."
            },
            new ArticleDto()
            {
                Id = Guid.NewGuid(),
                Title = "Lorem ipsum dolor sit amet.",
                PublicationDate = DateTime.Now,
                Category = "News",
                ShortSummary = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus lorem nulla, sollicitudin vitae mi id, maximus ultricies ante. Nullam non ipsum tortor. Pellentesque eget tempor sapien. Donec semper nisi quis posuere laoreet. Nunc a magna sit amet justo blandit feugiat. Vestibulum commodo lectus odio, sit amet pellentesque nisl consectetur ac. Maecenas vestibulum placerat augue, a tempus velit interdum elementum. Duis eget libero et turpis sagittis egestas non quis nisl."
            },
            new ArticleDto()
            {
                Id = Guid.NewGuid(),
                Title = "Lorem ipsum dolor sit amet.",
                PublicationDate = DateTime.Now,
                Category = "News",
                ShortSummary = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus lorem nulla, sollicitudin vitae mi id, maximus ultricies ante. Nullam non ipsum tortor. Pellentesque eget tempor sapien. Donec semper nisi quis posuere laoreet. Nunc a magna sit amet justo blandit feugiat. Vestibulum commodo lectus odio, sit amet pellentesque nisl consectetur ac. Maecenas vestibulum placerat augue, a tempus velit interdum elementum. Duis eget libero et turpis sagittis egestas non quis nisl."
            },
            new ArticleDto()
            {
                Id = Guid.NewGuid(),
                Title = "Lorem ipsum dolor sit amet.",
                PublicationDate = DateTime.Now,
                Category = "News",
                ShortSummary = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus lorem nulla, sollicitudin vitae mi id, maximus ultricies ante. Nullam non ipsum tortor. Pellentesque eget tempor sapien. Donec semper nisi quis posuere laoreet. Nunc a magna sit amet justo blandit feugiat. Vestibulum commodo lectus odio, sit amet pellentesque nisl consectetur ac. Maecenas vestibulum placerat augue, a tempus velit interdum elementum. Duis eget libero et turpis sagittis egestas non quis nisl."
            },
            new ArticleDto()
            {
                Id = Guid.NewGuid(),
                Title = "Lorem ipsum dolor sit amet.",
                PublicationDate = DateTime.Now,
                Category = "News",
                ShortSummary = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus lorem nulla, sollicitudin vitae mi id, maximus ultricies ante. Nullam non ipsum tortor. Pellentesque eget tempor sapien. Donec semper nisi quis posuere laoreet. Nunc a magna sit amet justo blandit feugiat. Vestibulum commodo lectus odio, sit amet pellentesque nisl consectetur ac. Maecenas vestibulum placerat augue, a tempus velit interdum elementum. Duis eget libero et turpis sagittis egestas non quis nisl."
            },
            new ArticleDto()
            {
                Id = Guid.NewGuid(),
                Title = "Lorem ipsum dolor sit amet.",
                PublicationDate = DateTime.Now,
                Category = "News",
                ShortSummary = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus lorem nulla, sollicitudin vitae mi id, maximus ultricies ante. Nullam non ipsum tortor. Pellentesque eget tempor sapien. Donec semper nisi quis posuere laoreet. Nunc a magna sit amet justo blandit feugiat. Vestibulum commodo lectus odio, sit amet pellentesque nisl consectetur ac. Maecenas vestibulum placerat augue, a tempus velit interdum elementum. Duis eget libero et turpis sagittis egestas non quis nisl."
            },
            new ArticleDto()
            {
                Id = Guid.NewGuid(),
                Title = "Lorem ipsum dolor sit amet.",
                PublicationDate = DateTime.Now,
                Category = "News",
                ShortSummary = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus lorem nulla, sollicitudin vitae mi id, maximus ultricies ante. Nullam non ipsum tortor. Pellentesque eget tempor sapien. Donec semper nisi quis posuere laoreet. Nunc a magna sit amet justo blandit feugiat. Vestibulum commodo lectus odio, sit amet pellentesque nisl consectetur ac. Maecenas vestibulum placerat augue, a tempus velit interdum elementum. Duis eget libero et turpis sagittis egestas non quis nisl."
            },
            new ArticleDto()
            {
                Id = Guid.NewGuid(),
                Title = "Lorem ipsum dolor sit amet.",
                PublicationDate = DateTime.Now,
                Category = "News",
                ShortSummary = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus lorem nulla, sollicitudin vitae mi id, maximus ultricies ante. Nullam non ipsum tortor. Pellentesque eget tempor sapien. Donec semper nisi quis posuere laoreet. Nunc a magna sit amet justo blandit feugiat. Vestibulum commodo lectus odio, sit amet pellentesque nisl consectetur ac. Maecenas vestibulum placerat augue, a tempus velit interdum elementum. Duis eget libero et turpis sagittis egestas non quis nisl."
            },
            new ArticleDto()
            {
                Id = Guid.NewGuid(),
                Title = "Lorem ipsum dolor sit amet.",
                PublicationDate = DateTime.Now,
                Category = "News",
                ShortSummary = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus lorem nulla, sollicitudin vitae mi id, maximus ultricies ante. Nullam non ipsum tortor. Pellentesque eget tempor sapien. Donec semper nisi quis posuere laoreet. Nunc a magna sit amet justo blandit feugiat. Vestibulum commodo lectus odio, sit amet pellentesque nisl consectetur ac. Maecenas vestibulum placerat augue, a tempus velit interdum elementum. Duis eget libero et turpis sagittis egestas non quis nisl."
            },
            new ArticleDto()
            {
                Id = Guid.NewGuid(),
                Title = "Lorem ipsum dolor sit amet.",
                PublicationDate = DateTime.Now,
                Category = "News",
                ShortSummary = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus lorem nulla, sollicitudin vitae mi id, maximus ultricies ante. Nullam non ipsum tortor. Pellentesque eget tempor sapien. Donec semper nisi quis posuere laoreet. Nunc a magna sit amet justo blandit feugiat. Vestibulum commodo lectus odio, sit amet pellentesque nisl consectetur ac. Maecenas vestibulum placerat augue, a tempus velit interdum elementum. Duis eget libero et turpis sagittis egestas non quis nisl."
            },
            new ArticleDto()
            {
                Id = Guid.NewGuid(),
                Title = "Lorem ipsum dolor sit amet.",
                PublicationDate = DateTime.Now,
                Category = "News",
                ShortSummary = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus lorem nulla, sollicitudin vitae mi id, maximus ultricies ante. Nullam non ipsum tortor. Pellentesque eget tempor sapien. Donec semper nisi quis posuere laoreet. Nunc a magna sit amet justo blandit feugiat. Vestibulum commodo lectus odio, sit amet pellentesque nisl consectetur ac. Maecenas vestibulum placerat augue, a tempus velit interdum elementum. Duis eget libero et turpis sagittis egestas non quis nisl."
            },
            new ArticleDto()
            {
                Id = Guid.NewGuid(),
                Title = "Lorem ipsum dolor sit amet.",
                PublicationDate = DateTime.Now,
                Category = "News",
                ShortSummary = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus lorem nulla, sollicitudin vitae mi id, maximus ultricies ante. Nullam non ipsum tortor. Pellentesque eget tempor sapien. Donec semper nisi quis posuere laoreet. Nunc a magna sit amet justo blandit feugiat. Vestibulum commodo lectus odio, sit amet pellentesque nisl consectetur ac. Maecenas vestibulum placerat augue, a tempus velit interdum elementum. Duis eget libero et turpis sagittis egestas non quis nisl."
            },
            new ArticleDto()
            {
                Id = Guid.NewGuid(),
                Title = "Lorem ipsum dolor sit amet.",
                PublicationDate = DateTime.Now,
                Category = "News",
                ShortSummary = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus lorem nulla, sollicitudin vitae mi id, maximus ultricies ante. Nullam non ipsum tortor. Pellentesque eget tempor sapien. Donec semper nisi quis posuere laoreet. Nunc a magna sit amet justo blandit feugiat. Vestibulum commodo lectus odio, sit amet pellentesque nisl consectetur ac. Maecenas vestibulum placerat augue, a tempus velit interdum elementum. Duis eget libero et turpis sagittis egestas non quis nisl."
            },
            };
        }
    }
}
