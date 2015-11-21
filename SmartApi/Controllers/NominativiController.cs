using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using SmartApi.Persistence.Dtos;
using SmartApi.Services.Abstracts;

namespace SmartApi.Controllers
{
    public class NominativiController : CommonController
    {
        private readonly INominativiServices _nominativiServices;

        public NominativiController(INominativiServices nominativiServices)
        {
            this._nominativiServices = nominativiServices;
        }

        [HttpGet]
        public async Task<IReadOnlyCollection<NominativiDto>> GetAnagraficaNominativiAsync(int pageIndex, int pageSize)
        {
            return await this._nominativiServices.GetAnagraficaNominativiAsync(pageIndex, pageSize);
        } 
    }
}