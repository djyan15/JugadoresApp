using FluentValidation;
using Jugadores.Core.Data;
using Jugadores.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jugadores.Infrastructure.Validators
{
    public class EquipoValidator :  AbstractValidator<EquiposDto>
    {

        public EquipoValidator()
        {
            RuleFor(equipo => equipo.EquipoNombre)
                .NotNull().WithMessage("El '{PropertyName}' no puede ser vacio")
                .Length(3, 50).WithMessage("'{PropertyName}' debe tener entre 3 y 50 carácteres");

            RuleFor(equipo => equipo.EquipoFechaCreacion)
                .LessThanOrEqualTo(DateTime.Now)
                .WithMessage("La '{PropertyName}' debe ser menor o igual a la actual"); 


        }
    }
}
