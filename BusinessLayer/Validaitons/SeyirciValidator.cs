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
            //Rule for KullaniciAd
            RuleFor(kullanici => kullanici.kullaniciAd).NotEmpty().WithMessage("Kullanıcı Adı boş geçilemez!");
            RuleFor(kullanici => kullanici.kullaniciAd).MaximumLength(50).WithMessage("Maximum 50 karakter girilmelidir.");
            RuleFor(kullanici => kullanici.kullaniciAd).MinimumLength(2).WithMessage("Minimum 2 karakter girilmelidir.");

            //Rule for KullaniciSifre
            RuleFor(kullanici => kullanici.kullaniciSifre).NotEmpty().WithMessage("Kullanıcı Şifresi boş geçilemez!");
            RuleFor(kullanici => kullanici.kullaniciSifre).MaximumLength(50).WithMessage("Maximum 50 karakter girilmelidir.");
            RuleFor(kullanici => kullanici.kullaniciSifre).MinimumLength(2).WithMessage("Minimum 2 karakter girilmelidir.");

            //Rule for  seyirciAd
            RuleFor(kullanici => kullanici.seyirciAd).NotEmpty().WithMessage("Seyirci Adı boş geçilemez!");
            RuleFor(kullanici => kullanici.seyirciAd).MaximumLength(50).WithMessage("Maximum 50 karakter girilmelidir.");
            RuleFor(kullanici => kullanici.seyirciAd).MinimumLength(2).WithMessage("Minimum 2 karakter girilmelidir.");

            //Rule for  seyirciSoyad
            RuleFor(kullanici => kullanici.seyirciSoyad).NotEmpty().WithMessage("Seyirci Soyadı boş geçilemez!");
            RuleFor(kullanici => kullanici.seyirciSoyad).MaximumLength(50).WithMessage("Maximum 50 karakter girilmelidir.");
            RuleFor(kullanici => kullanici.seyirciSoyad).MinimumLength(2).WithMessage("Minimum 2 karakter girilmelidir.");

            //Rule for  dogumTarihi
            RuleFor(kullanici => kullanici.dogumTarihi).NotEmpty().WithMessage("Doğum Tarihi boş geçilemez!");

            //Rule for  kullaniciTc
            RuleFor(kullanici => kullanici.kullaniciTc).NotEmpty().WithMessage("Kullanıcı TC boş geçilemez!");
            RuleFor(kullanici => kullanici.kullaniciTc).MaximumLength(11).WithMessage("Maximum 11 karakter girilmelidir.");
            RuleFor(kullanici => kullanici.kullaniciTc).MinimumLength(11).WithMessage("Minimum 11 karakter girilmelidir.");

            //Rule for kullaniciMail
            RuleFor(kullanici => kullanici.kullaniciMail).NotEmpty().WithMessage("Kullanıcı mail boş geçilemez!");
            RuleFor(kullanici => kullanici.kullaniciMail).MaximumLength(50).WithMessage("Maximum 50 karakter girilmelidir.");
            RuleFor(kullanici => kullanici.kullaniciMail).MinimumLength(2).WithMessage("Minimum 2 karakter girilmelidir.");

            //Rule for  kullaniciTel
            RuleFor(kullanici => kullanici.kullaniciTel).NotEmpty().WithMessage("Kullanıcı tel boş geçilemez!");
            RuleFor(kullanici => kullanici.kullaniciTel).MaximumLength(11).WithMessage("Maximum 11 karakter girilmelidir.");
            RuleFor(kullanici => kullanici.kullaniciTel).MinimumLength(11).WithMessage("Minimum 11  karakter girilmelidir.");
        }
    }
}
