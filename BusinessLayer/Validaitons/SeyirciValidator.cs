using EntityLayer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validaitons
{
    public class SeyirciValidator : AbstractValidator<Seyirci>
    {
        public SeyirciValidator()
        {
            RuleFor(seyirci => seyirci.seyirciAd).NotEmpty().WithMessage("Seyirci adı boş geçilemez!");
            RuleFor(seyirci => seyirci.seyirciAd).MaximumLength(25).WithMessage("Maksimum 25 karakter girebilirsiniz.");
            RuleFor(seyirci => seyirci.seyirciAd).MinimumLength(2).WithMessage("Minimum 2 karakter girebilirsiniz.");

            RuleFor(seyirci => seyirci.seyirciSoyad).NotEmpty().WithMessage("Seyirci soyadı boş geçilemez!");
            RuleFor(seyirci => seyirci.seyirciSoyad).MaximumLength(25).WithMessage("Maksimum 25 karakter girebilirsiniz.");
            RuleFor(seyirci => seyirci.seyirciSoyad).MinimumLength(2).WithMessage("Minimum 2 karakter girebilirsiniz.");

            RuleFor(seyirci => seyirci.seyirciTc).NotEmpty().WithMessage("Seyirci Tc boş geçilemez!");
            RuleFor(seyirci => seyirci.seyirciTc).MaximumLength(11).WithMessage("Maksimum 11 karakter girebilirsiniz.");
            RuleFor(seyirci => seyirci.seyirciTc).MinimumLength(11).WithMessage("Minimum 11 karakter girebilirsiniz.");

            RuleFor(seyirci => seyirci.kullaniciAd).NotEmpty().WithMessage("Kullanıcı adı boş geçilemez!");
            RuleFor(seyirci => seyirci.kullaniciAd).MaximumLength(50).WithMessage("Maximum 50 karakter girilmelidir.");
            RuleFor(seyirci => seyirci.kullaniciAd).MinimumLength(2).WithMessage("Minimum 2 karakter girilmelidir.");

            RuleFor(seyirci => seyirci.kullaniciSifre).NotEmpty().WithMessage("Kullanıcı şifresi boş geçilemez!");
            RuleFor(seyirci => seyirci.kullaniciSifre).MaximumLength(50).WithMessage("Maximum 50 karakter girilmelidir.");
            RuleFor(seyirci => seyirci.kullaniciSifre).MinimumLength(2).WithMessage("Minimum 2 karakter girilmelidir.");

            RuleFor(seyirci => seyirci.dogumTarihi).NotEmpty().WithMessage("Doğum tarihi boş geçilemez!");

            RuleFor(seyirci => seyirci.kullaniciMail).NotEmpty().WithMessage("Kullanıcı mail boş geçilemez!");
            RuleFor(seyirci => seyirci.kullaniciMail).MaximumLength(50).WithMessage("Maximum 50 karakter girilmelidir.");
            RuleFor(seyirci => seyirci.kullaniciMail).MinimumLength(2).WithMessage("Minimum 2 karakter girilmelidir.");

            RuleFor(seyirci => seyirci.kullaniciTel).NotEmpty().WithMessage("Kullanıcı tel boş geçilemez!");
            RuleFor(seyirci => seyirci.kullaniciTel).MaximumLength(11).WithMessage("Maximum 11 karakter girilmelidir.");
            RuleFor(seyirci => seyirci.kullaniciTel).MinimumLength(11).WithMessage("Minimum 11  karakter girilmelidir.");
        }
    }
}