using AjudaAmigos.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AjudaAmigos.Service.Validators
{
    public class UsuarioValidator : AbstractValidator<Usuario>
    {
        public UsuarioValidator()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("Nome Obrigatório.")
                .NotNull().WithMessage("Nome Obrigatório.");

            RuleFor(c => c.Login)
                .NotEmpty().WithMessage("Login Obrigatório.")
                .NotNull().WithMessage("Login Obrigatório.");

            RuleFor(c => c.Senha)
                .NotEmpty().WithMessage("Senha Obrigatório.")
                .NotNull().WithMessage("Senha Obrigatório.");
        }
    }
}
