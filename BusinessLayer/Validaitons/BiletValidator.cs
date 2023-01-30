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

            RuleFor(bilet => bilet.seyirciAd).NotEmpty().WithMessage("Seyirci adı boş geçilemez!");
            RuleFor(bilet => bilet.seyirciAd).MaximumLength(25).WithMessage("Maksimum 25 karakter girebilirsiniz.");
            RuleFor(bilet => bilet.seyirciAd).MinimumLength(3).WithMessage("Minimum 3 karakter girebilirsiniz.");

            RuleFor(bilet => bilet.seyirciSoyad).NotEmpty().WithMessage("Seyirci soyadı boş geçilemez!");
            RuleFor(bilet => bilet.seyirciSoyad).MaximumLength(25).WithMessage("Maksimum 25 karakter girebilirsiniz.");
            RuleFor(bilet => bilet.seyirciSoyad).MinimumLength(3).WithMessage("Minimum 3 karakter girebilirsiniz.");

            RuleFor(bilet => bilet.seyirciTc).NotEmpty().WithMessage("Seyirci TC boş geçilemez!");
            RuleFor(bilet => bilet.seyirciTc).MaximumLength(25).WithMessage("Maksimum 11 karakter girebilirsiniz.");

            RuleFor(bilet => bilet.seyirciTur).NotEmpty().WithMessage("Seyirci türü boş geçilemez!");
            RuleFor(bilet => bilet.seyirciTur).MaximumLength(50).WithMessage("Maksimum 50 karakter girebilirsiniz.");
            RuleFor(bilet => bilet.seyirciTur).MinimumLength(4).WithMessage("Minimum 4 karakter girebilirsiniz.");

            RuleFor(bilet => bilet.odemeTipi).NotEmpty().WithMessage("Ödeme tipi boş geçilemez!");

            RuleFor(bilet => bilet.biletKesimTarihi).NotEmpty().WithMessage("Bilet kesim tarihi boş geçilemez!");

            RuleFor(bilet => bilet.fiyat).NotEmpty().WithMessage("Bilet fiyatı boş geçilemez !");
            RuleFor(bilet => bilet.fiyat).GreaterThan(0.00).WithMessage("Daha yüksek fiyat girmelisiniz !");
        }
    }
}