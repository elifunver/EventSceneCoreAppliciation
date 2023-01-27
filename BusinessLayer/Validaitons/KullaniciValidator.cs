using EntityLayer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validaitons
{
    public class KullaniciValidator : AbstractValidator<Kullanici>
    {
        public KullaniciValidator()
        {
            RuleFor(kullanici => kullanici.kullaniciAd).NotEmpty().WithMessage("kullanici adı boş geçilemez!");
            RuleFor(kullanici => kullanici.kullaniciAd).MaximumLength(25).WithMessage("Maksimum 25 karakter girebilirsiniz.");
            RuleFor(kullanici => kullanici.kullaniciAd).MinimumLength(2).WithMessage("Minimum 2 karakter girebilirsiniz.");

            RuleFor(kullanici => kullanici.kullaniciSifre).NotEmpty().WithMessage("Kullanıcı şifresi boş geçilemez!");
            RuleFor(kullanici => kullanici.kullaniciSifre).MaximumLength(50).WithMessage("Maximum 50 karakter girilmelidir.");
            RuleFor(kullanici => kullanici.kullaniciSifre).MinimumLength(2).WithMessage("Minimum 2 karakter girilmelidir.");

            RuleFor(kullanici => kullanici.kullaniciTc).NotEmpty().WithMessage("kullanici Tc boş geçilemez!");
            RuleFor(kullanici => kullanici.kullaniciTc).MaximumLength(11).WithMessage("Maksimum 11 karakter girebilirsiniz.");
            RuleFor(kullanici => kullanici.kullaniciTc).MinimumLength(11).WithMessage("Minimum 11 karakter girebilirsiniz.");

            RuleFor(kullanici => kullanici.kullaniciTel).NotEmpty().WithMessage("Kullanıcı tel boş geçilemez!");
            RuleFor(kullanici => kullanici.kullaniciTel).MaximumLength(11).WithMessage("Maximum 11 karakter girilmelidir.");
            RuleFor(kullanici => kullanici.kullaniciTel).MinimumLength(11).WithMessage("Minimum 11  karakter girilmelidir.");

            RuleFor(kullanici => kullanici.kullaniciMail).NotEmpty().WithMessage("Kullanıcı mail boş geçilemez!");
            RuleFor(kullanici => kullanici.kullaniciMail).MaximumLength(50).WithMessage("Maximum 50 karakter girilmelidir.");
            RuleFor(kullanici => kullanici.kullaniciMail).MinimumLength(2).WithMessage("Minimum 2 karakter girilmelidir.");

            RuleFor(kullanici => kullanici.dogumTarihi).NotEmpty().WithMessage("Doğum tarihi boş geçilemez!");
        }
    }
}