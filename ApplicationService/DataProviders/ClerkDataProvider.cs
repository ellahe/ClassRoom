using System.Net;
using ApplicationService.DTOS;
using AutoMapper;
using Domain.Domains;
using Infrastructure.Repositories;

namespace ApplicationService.DataProviders
{
    public interface IClerkDataProvider
    {
        long Add(ClerkDTO clerkDTO);
        void Update(ClerkDTO clerkDTO);
        ClerkDTO Get(long id);
    }

    public class ClerkDataProvider : IClerkDataProvider
    {
        public ClerkDataProvider(
            IMapper mapper,
            IRepository<ClerkEntity> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        private readonly IMapper _mapper;
        private readonly IRepository<ClerkEntity> _repository;

        public long Add(ClerkDTO clerkDTO)
        {
            var poco = new ClerkEntity();
            poco = _mapper.Map<ClerkDTO, ClerkEntity>(clerkDTO, poco);
            return _repository.Add(poco);
        }

        public ClerkDTO Get(long id)
        {
            var poco = _repository.Get(id);
            return  _mapper.Map<ClerkEntity, ClerkDTO>(poco);
        }

        public void Update(ClerkDTO clerkDTO)
        {
            throw new System.NotImplementedException();
        }
    }
}
