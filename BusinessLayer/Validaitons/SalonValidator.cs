using EntityLayer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validaitons
{
    public class SalonValidator: AbstractValidator<Salon>
    {
        public SalonValidator()
        {

            //Rule for salonad
            RuleFor(salon => salon.salonAd).NotEmpty().WithMessage("Salon adı boş geçilemez!");
            RuleFor(salon => salon.salonAd).MaximumLength(50).WithMessage("Maximum 50 karakter girilmelidir.");
            RuleFor(salon => salon.salonAd).MinimumLength(2).WithMessage("Minimum 2 karakter girilmelidir.");

            //Rule For salonId
            RuleFor(salon => salon.salonId).NotEmpty().WithMessage("Salon Id boş geçilemez!");

        }

    }
}
