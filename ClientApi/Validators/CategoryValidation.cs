using ClientApi.Dtos;
using ClientApi.Services.DataModels;
using FluentValidation;

namespace ClientApi.Validators
{
    public class CategoryValidation : AbstractValidator<CategoryDto>
    {
        public CategoryValidation()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Name).Length(3, 10);
        }
    }
}
