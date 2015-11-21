using System.Collections.Generic;
using System.Threading.Tasks;
using SmartApi.Shared.Dtos;

namespace SmartApi.Services.Abstracts
{
    public interface IArticoliServices
    {
        void CreateArticolo(ArticoliDto articoloToCreate);

        Task<IList<ArticoliDto>> GetAnagraficaArticoliAsync(int pageIndex, int pageSize);

        Task<ArticoliDto> GetArticoloAsync(string codicerticolo);
    }
}