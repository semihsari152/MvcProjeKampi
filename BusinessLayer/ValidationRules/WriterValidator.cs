using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator:AbstractValidator<Writer>
    {
       public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar Adı Boş Olamaz.");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Yazar Maili Boş Olamaz");
            RuleFor(x => x.WriterSurName).NotEmpty().WithMessage("Yazar Soyadı Boş Olamaz");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Yazar Unvanı Boş Olamaz");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkında kısmı boş olamaz ");
            RuleFor(x => x.WriterSurName).MinimumLength(2).WithMessage("Lütfen en az 2 karakter giriş yapın.");
            RuleFor(x => x.WriterSurName).MaximumLength(50).WithMessage("Lütfen 50'den fazla karakter girişi yapmayın.");

        }
    }
}
