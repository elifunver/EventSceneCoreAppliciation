using EntityLayer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validaitons
{
    public class SeansValidator : AbstractValidator<Seans>
    {
        public SeansValidator()
        {
            RuleFor(seans => seans.sure).NotEmpty().WithMessage("Seans süresi boş geçilemez!");

            RuleFor(seans => seans.saat).NotEmpty().WithMessage("Seans saati boş geçilemez !");
            RuleFor(seans => seans.saat).MaximumLength(5).WithMessage("Maksimum 5 karakter girebilirsiniz.");
            RuleFor(seans => seans.saat).MinimumLength(5).WithMessage("Minimum 5 karakter girebilirsiniz.");

            RuleFor(seans => seans.tarih).NotEmpty().WithMessage("Seans tarihi boş geçilemez!");
        }
    }
}