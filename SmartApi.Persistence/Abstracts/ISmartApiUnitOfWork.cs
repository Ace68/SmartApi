using System.Threading.Tasks;
using SmartApi.Shared.Dtos;

namespace SmartApi.Persistence.Abstracts
{
    public interface ISmartApiUnitOfWork
    {
        ISmartApiRepository<ArticoliDto> ArticoliRepository { get; }

        Task CommitAsync();
    }
}
