
using ClientApi.Dtos;
using FluentValidation;

namespace ClientApi.Validators
{
    public class UserValidation : AbstractValidator<RegisterDto>
    {
        public UserValidation()
        {
            RuleFor(x => x.Username).NotEmpty();
            RuleFor(x => x.Username).Length(3, 25);
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.Password).Length(4, 20);
        }
    }

}
