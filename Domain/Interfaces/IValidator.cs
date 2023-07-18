using System.Collections.Generic;
using Domain.Domains;
using Infrastructure.Services;

namespace Domain.Interfaces
{
    public interface IValidator<T> where T : Entity
    {
        ICollection<ValidatorResult> Validate(T entity);
    }
}
