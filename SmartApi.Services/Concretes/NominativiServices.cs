using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

using SmartApi.Persistence.Abstracts;
using SmartApi.Persistence.Dtos;
using SmartApi.Services.Abstracts;

namespace SmartApi.Services.Concretes
{
    public class NominativiServices : INominativiServices
    {
        private readonly ISmartApiUnitOfWork _smartApiUnitOfWork;

        public NominativiServices(ISmartApiUnitOfWork smartApiUnitOfWork)
        {
            this._smartApiUnitOfWork = smartApiUnitOfWork;
        }

        public async Task UpdateNominativoAsync(NominativiDto nominativoToCreate)
        {
            var nominativiResults = await 
                this._smartApiUnitOfWork.NominativiRepository.QueryAsync(
                    n => n.RagioneSociale == nominativoToCreate.RagioneSociale);

            if (nominativiResults.Any())
            {
                nominativiResults.First().RagioneSociale = nominativoToCreate.RagioneSociale;
                this._smartApiUnitOfWork.NominativiRepository.Update(nominativiResults.First());
                await this._smartApiUnitOfWork.CommitAsync();

                return;
            }

            var nominativo = new NominativiDto
            {
                RagioneSociale = nominativoToCreate.RagioneSociale
            };

            this._smartApiUnitOfWork.NominativiRepository.Insert(nominativo);
            await this._smartApiUnitOfWork.CommitAsync();
        }

        public async Task<IReadOnlyCollection<NominativiDto>> GetAnagraficaNominativiAsync(int pageIndex, int pageSize)
        {
            var listaNominativi = await this._smartApiUnitOfWork.NominativiRepository.GetAllAsync(pageIndex, pageSize);

            return new ReadOnlyCollection<NominativiDto>(listaNominativi);
        }

        public async Task<NominativiDto> GetNominativoByIdAsync(int nominativoId)
        {
            return await this._smartApiUnitOfWork.NominativiRepository.GetByIdAsync(nominativoId);
        }
    }
}