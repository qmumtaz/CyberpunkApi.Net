
using ClientApi.Dtos;
using ClientApi.Services.DataModels;
using FluentValidation;

namespace ClientApi.Validators
{
    public class PostValidation : AbstractValidator<PostDto>
    {
        public PostValidation()
        {
            RuleFor(model => model.Title).Length(5, 50);
            RuleFor(model => model.Description).Length(5, 50);
        }
    }
}
