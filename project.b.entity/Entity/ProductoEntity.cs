using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.b.entity.Entity
{
    public class ProductoEntity
    {
        public int id { get; set; }
        public string? nombre { get; set; }
        public TipoEntity? tipo { get; set; }
        public PaisEntity? pais { get; set; }
        public double precio { get; set; }
    }

    public class ProductoEntityValidator : AbstractValidator<ProductoEntity>
    {
        public ProductoEntityValidator()
        {
            RuleFor(x => x.nombre).NotEmpty().MaximumLength(20).WithMessage("Debe tener máximo 20 caracteres");
            RuleFor(x => x.precio).NotEmpty().GreaterThan(5).WithMessage("No puede ser menor a 5 dólares");
        }
    }
}
