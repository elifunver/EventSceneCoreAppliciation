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

            //Rule For SeriNo
            RuleFor(bilet => bilet.seriNo).NotEmpty().WithMessage("Seri No Boş geçilemez!");
            RuleFor(bilet => bilet.seriNo).MaximumLength(50).WithMessage("Maksimum 50 karakter girebilirsiniz.");
            RuleFor(bilet => bilet.seriNo).MinimumLength(4).WithMessage("Minimum 4 karakter girebilirsiniz.");

            //Rule For BiletKesimTarihi
            RuleFor(bilet => bilet.biletKesimTarihi).NotEmpty().WithMessage("Bilet kesim tarihi boş geçilemez!");

            //Rule For SeyirciAd
            RuleFor(bilet => bilet.seyirciAd).NotEmpty().WithMessage("Seyirci Adı Boş geçilemez!");
            RuleFor(bilet => bilet.seyirciAd).MaximumLength(25).WithMessage("Maksimum 25 karakter girebilirsiniz.");
            RuleFor(bilet => bilet.seyirciAd).MinimumLength(2).WithMessage("Minimum 2 karakter girebilirsiniz.");

            //Rule For SeyirciSoyad
            RuleFor(bilet => bilet.seyirciSoyad).NotEmpty().WithMessage("Seyirci Soyadı Boş geçilemez!");
            RuleFor(bilet => bilet.seyirciSoyad).MaximumLength(25).WithMessage("Maksimum 25 karakter girebilirsiniz.");
            RuleFor(bilet => bilet.seyirciSoyad).MinimumLength(2).WithMessage("Minimum 2 karakter girebilirsiniz.");

            //Rule For SeyirciTc
            RuleFor(bilet => bilet.seyirciTc).NotEmpty().WithMessage("Seyirci Tc Boş geçilemez!");
            RuleFor(bilet => bilet.seyirciTc).MaximumLength(11).WithMessage("Maksimum 11 karakter girebilirsiniz.");
            RuleFor(bilet => bilet.seyirciTc).MinimumLength(11).WithMessage("Minimum 11 karakter girebilirsiniz.");

            //Rule For SeansId
            RuleFor(bilet => bilet.seansId).NotEmpty().WithMessage("Seans Id tarihi boş geçilemez!");

            //Rule For SeyirciId
            RuleFor(bilet => bilet.seyirciId).NotEmpty().WithMessage("Seyirci Id tarihi boş geçilemez!");



        }



    }
}
