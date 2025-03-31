using CryptCloud.Models;
using FluentValidation;

namespace CryptCloud.Infrastructure.Validators;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(u => u.Email)
            .NotEmpty().WithMessage("Email обязателен")
            .EmailAddress().WithMessage("Некорректный формат email")
            .MaximumLength(100).WithMessage("Максимальная длина 100 символов");;

        RuleFor(u => u.Password)
            .NotEmpty().WithMessage("Пароль обязателен")
            .MinimumLength(8).WithMessage("Минимальная длина пароля 8 символов")
            .Matches(@"^(?=.*\d)(?=.*[a-zA-Z]).*$").WithMessage("Пароль должен содержать хотя бы 1 цифру и 1 букву")
            .MaximumLength(50).WithMessage("Максимальная длина 50 символов");
    }
}