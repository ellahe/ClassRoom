using ApplicationService.DTOS;
using AutoMapper;
using Domain.Domains;
using Domain.Validators;
using Infrastructure.Repositories;
using Infrastructure.Services;

namespace ApplicationService.DataProviders
{
    public interface IClerkDataProvider
    {
        long Add(ClerkDTO clerkDTO);
        void Update(ClerkDTO clerkDTO);
        ClerkDTO GetByUserNameAndPassword(string userName, string password);
        void validateUserName(string userName);
        void validateEmail(string Email);
        void validateMobileNumber(string mobileNumber);
    }

    public class ClerkDataProvider : IClerkDataProvider
    {
        public ClerkDataProvider(
            IMapper mapper,
            IClerkRepository repository, 
            IClerkValidator clerkValidator)
        {
            _mapper = mapper;
            _repository = repository;
            _clerkValidator = clerkValidator;
        }

        private readonly IMapper _mapper;
        private readonly IClerkRepository _repository;
        private readonly IClerkValidator _clerkValidator;

        public long Add(ClerkDTO clerkDTO)
        {
            var poco = new ClerkEntity();
            poco = _mapper.Map(clerkDTO, poco);
            return _repository.Add(poco);
        }

        public ClerkDTO GetByUserNameAndPassword(string userName, string password)
        {
            var poco = _repository.GetByUserNameAndPassword(userName, password);
            return  _mapper.Map<ClerkEntity, ClerkDTO>(poco);
        }

        public void Update(ClerkDTO clerkDTO)
        {
            var poco = new ClerkEntity();
            poco = _mapper.Map(clerkDTO, poco);
             _repository.Update(poco);
        }

        public void validateUserName(string userName)
        {
            ErrorHappenedException.ThrowFromValidation(_clerkValidator.ValidateUserName(userName));
        }

        public void validateEmail(string Email)
        {
            ErrorHappenedException.ThrowFromValidation(_clerkValidator.ValidateEmail(Email));
        }

        public void validateMobileNumber(string mobileNumber)
        {
            ErrorHappenedException.ThrowFromValidation(_clerkValidator.ValidateMobileNumber(mobileNumber));
        }
    }
}
