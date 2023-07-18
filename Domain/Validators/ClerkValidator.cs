using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Domain.Domains;
using Domain.Interfaces;
using Infrastructure.Repositories;
using Infrastructure.Services;

namespace Domain.Validators
{
    public interface IClerkValidator : IValidator<ClerkEntity>
    {
        ValidatorResult ValidateUserName(string userName);
        ValidatorResult ValidateEmail(string email);
        ValidatorResult ValidateMobileNumber(string mobile);
    }

    public class ClerkValidator : IClerkValidator
    {
        public ClerkValidator(IClerkRepository clerkRepository)
        {
            _clerkRepository = clerkRepository;
            _clerks = _clerkRepository.GetAll();
        }

        private readonly IClerkRepository _clerkRepository;
        private List<ClerkEntity> _clerks = new List<ClerkEntity>();

        public ICollection<ValidatorResult> Validate(ClerkEntity clerkEntity)
        {
            var error = new Collection<ValidatorResult>();
            error.Add(ValidateUserName(clerkEntity.UserName));
            error.Add(ValidateEmail(clerkEntity.Email));
            error.Add(ValidateMobileNumber(clerkEntity.MobileNumber));
            return error;
        }

        public ValidatorResult ValidateUserName(string userName)
        {
            return _clerks.Any(x => x.UserName == userName)?
                 new ValidatorResult(false, "این نام کاربری قبلا استفاده شده است", "") :
                 ValidatorResult.Empty;
        }

        public ValidatorResult ValidateEmail(string email)
        {
            return _clerks.Any(x => x.Email == email) ?
                    new ValidatorResult(false, "این ایمیل قبلا استفاده شده است", "") :
                    ValidatorResult.Empty;

        }

        public ValidatorResult ValidateMobileNumber(string mobile)
        {
            return _clerks.Any(x => x.MobileNumber == mobile) ?
               new ValidatorResult(false, "این شماره تلفن قبلا استفاده شده است", "") :
               ValidatorResult.Empty;
        }
    }
}
