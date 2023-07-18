using System.Collections.Generic;
using Domain.Domains;
using Infrastructure.Services;

namespace Domain.Interfaces
{
    public interface Inquiery<T> where T : Entity
    {
        ICollection<ValidatorResult> Inquiry(T entity);
    }

    public class InquiryResult
    {
        public bool IsUsed { get; set; }
        public string Message { get; set; }
        public string MessageDetail { get; set; }
    }
}
