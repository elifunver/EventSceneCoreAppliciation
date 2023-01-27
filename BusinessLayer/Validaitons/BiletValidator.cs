using EntityLayer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validaitons
{
    public class BiletValidator : AbstractValidator<Bilet>
    {
        public BiletValidator()
        {
            RuleFor(bilet => bilet.seriNo).NotEmpty().WithMessage("Seri no boş geçilemez!");
            RuleFor(bilet => bilet.seriNo).MaximumLength(50).WithMessage("Maksimum 50 karakter girebilirsiniz.");
            RuleFor(bilet => bilet.seriNo).MinimumLength(4).WithMessage("Minimum 4 karakter girebilirsiniz.");

            RuleFor(bilet => bilet.biletKesimTarihi).NotEmpty().WithMessage("Bilet kesim tarihi boş geçilemez!");

            RuleFor(bilet => bilet.fiyat).NotEmpty().WithMessage("Bilet fiyatı boş geçilemez !");
            RuleFor(bilet => bilet.fiyat).GreaterThan(0.00).WithMessage("Daha yüksek fiyat girmelisiniz !");
        }
    }
}