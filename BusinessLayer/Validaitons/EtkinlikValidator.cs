using EntityLayer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validaitons
{
    public class EtkinlikValidator : AbstractValidator<Etkinlik>
    {
        public EtkinlikValidator()
        {
            //Rule for etkinlikad
            RuleFor(etkinlik => etkinlik.etkinlikAd).NotEmpty().WithMessage("Etkinlik adı boş geçilemez!");
            RuleFor(etkinlik => etkinlik.etkinlikAd).MaximumLength(50).WithMessage("Maximum 50 karakter girilmelidir.");
            RuleFor(etkinlik => etkinlik.etkinlikAd).MinimumLength(2).WithMessage("Minimum 2 karakter girilmelidir.");

            //Rule for acıklama
            RuleFor(etkinlik => etkinlik.aciklama).NotEmpty().WithMessage("Etkinlik Açıklması boş geçilemez!");
            RuleFor(etkinlik => etkinlik.aciklama).MaximumLength(6000).WithMessage("Maximum 6000 karakter girilmelidir.");
            RuleFor(etkinlik => etkinlik.aciklama).MinimumLength(3).WithMessage("Minimum 3 karakter girilmelidir.");

            

        }

    }
}
