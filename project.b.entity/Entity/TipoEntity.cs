using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.b.entity.Entity
{
    public class TipoEntity
    {
        public int id { get; set; }
        public string? descripcion { get; set; }
    }
    public class TipoEntityValidator : AbstractValidator<TipoEntity>
    {
        public TipoEntityValidator()
        {
            RuleFor(x => x.descripcion).NotEmpty().MaximumLength(20).WithMessage("Debe de ser menor a 20 caracteres");
            RuleFor(x => x.id).NotEmpty().WithMessage("No debe ser nulo");
        }
    }
}
