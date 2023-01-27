using EntityLayer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validaitons
{
    public class TurValidator : AbstractValidator<Tur>
    {
        public TurValidator()
        {
            //Rule For turad
            RuleFor(tur => tur.turAd).NotEmpty().WithMessage("Tür adı boş geçilemez!");
            RuleFor(tur => tur.turAd).MaximumLength(50).WithMessage("Maksimum 50 karakter girebilirsiniz.");
            RuleFor(tur => tur.turAd).MinimumLength(4).WithMessage("Minimum 4 karakter girebilirsiniz.");
        }
    }
}