using MediatR;

namespace AspNetNewsAgregator.Data.CQS.Commands
{
    public class UpdateArticleTextCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
    }
}
