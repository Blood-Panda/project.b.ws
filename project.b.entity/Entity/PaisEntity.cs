using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.b.entity.Entity
{
    public class PaisEntity
    {
        public int id { get; set; }
        public string? descripcion { get; set; }
    }
    public class PaisEntityValidator: AbstractValidator<PaisEntity>
    {
        public PaisEntityValidator()
        {
            RuleFor(x => x.descripcion).NotEmpty().MaximumLength(10).WithMessage("No debe ser mayor a 10 caracteres");
            RuleFor(x => x.id).NotEmpty().WithMessage("No debe ser nulo");
        }
    }
}
