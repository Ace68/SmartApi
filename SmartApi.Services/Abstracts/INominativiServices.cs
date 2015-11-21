using System.Collections.Generic;
using System.Threading.Tasks;
using SmartApi.Persistence.Dtos;

namespace SmartApi.Services.Abstracts
{
    public interface INominativiServices
    {
        Task UpdateNominativoAsync(NominativiDto nominativoToCreate);

        Task<IReadOnlyCollection<NominativiDto>> GetAnagraficaNominativiAsync(int pageIndex, int pageSize);

        Task<NominativiDto> GetNominativoByIdAsync(int nominativoId);
    }
}