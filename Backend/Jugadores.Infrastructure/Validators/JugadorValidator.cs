using FluentValidation;
using Jugadores.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jugadores.Infrastructure.Validators
{
    public class JugadorValidator : AbstractValidator<JugadorDto>
    {

        public JugadorValidator()
        {
            RuleFor(jugador => jugador.JugadorNombre)
                .NotNull().WithMessage("El '{PropertyName}' no puede ser vacio")
                  .Length(3, 50).WithMessage("'{PropertyName}' debe tener entre 3 y 50 carácteres");

            RuleFor(jugador => jugador.JugadorApellido)
               .NotNull().WithMessage("El '{PropertyName}' no puede ser vacio")
                 .Length(3, 50).WithMessage("'{PropertyName}' debe tener entre 3 y 50 carácteres");

            RuleFor(jugador => jugador.JugadorFechaNacimiento)
                .NotNull().WithMessage("El '{PropertyName}' no puede ser vacio")
                .LessThan(DateTime.Now)
                .WithMessage("'{PropertyName}' debe ser menor a la actual");

            RuleFor(jugador => jugador.JugadorSexo)
                .NotNull().WithMessage("El '{PropertyName}' no puede ser vacio")
                .Length(1, 1).WithMessage("'{PropertyName}' debe tener 1 caracter");
        }
    }
}
