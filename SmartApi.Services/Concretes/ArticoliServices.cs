using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartApi.Persistence.Abstracts;
using SmartApi.Services.Abstracts;
using SmartApi.Shared.Dtos;

namespace SmartApi.Services.Concretes
{
    public class ArticoliServices : IArticoliServices
    {
        private readonly ISmartApiUnitOfWork _smartApiUnitOfWork;

        public ArticoliServices(ISmartApiUnitOfWork smartApiUnitOfWork)
        {
            this._smartApiUnitOfWork = smartApiUnitOfWork;
        }

        public void CreateArticolo(ArticoliDto articoloToCreate)
        {
            this._smartApiUnitOfWork.ArticoliRepository.Insert(articoloToCreate);
            this._smartApiUnitOfWork.CommitAsync();
        }

        public async Task<IList<ArticoliDto>> GetAnagraficaArticoliAsync(int pageIndex, int pageSize)
        {
            return await this._smartApiUnitOfWork.ArticoliRepository.GetAllAsync(pageIndex, pageSize);
        }

        public async Task<ArticoliDto> GetArticoloAsync(string codicerticolo)
        {
            var articoliResults =
                await this._smartApiUnitOfWork.ArticoliRepository.QueryAsync(a => a.CodiceArticolo == codicerticolo);

            if (articoliResults.Any())
                return articoliResults.First();

            return new ArticoliDto();
        }
    }
}