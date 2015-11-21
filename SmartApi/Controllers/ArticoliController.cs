using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using SmartApi.Services.Abstracts;
using SmartApi.Shared.Dtos;

namespace SmartApi.Controllers
{
    public class ArticoliController : ApiController
    {
        private readonly IArticoliServices _articoliServices;

        protected string TokenId;
        protected string AuthenticationType;
        protected string User;

        public ArticoliController(IArticoliServices articoliServices)
        {
            this._articoliServices = articoliServices;
        }

        [HttpGet]
        public async Task<List<ArticoliDto>> GetAnagraficaArticoliAsync(int pageIndex, int pageSize)
        {
            var headers = this.ControllerContext.Request.Headers;

            this.AuthenticationType = this.ControllerContext.Request.Headers.Authorization.Scheme;

            foreach (var header in headers)
            {
                if (header.Key == "SmartToken")
                    this.TokenId = header.Value.First();

                if (header.Key == "Authorization")
                {
                    // Recupero la stringa di Autorizzazione Codificata
                    this.User = header.Value.First();

                    this.User = this.User.Replace(this.AuthenticationType, "").Trim();
                    this.User = Encoding.UTF8.GetString(Convert.FromBase64String(this.User));
                }
            }

            var elencoArticoli = await this._articoliServices.GetAnagraficaArticoliAsync(pageIndex, pageSize);

            return new List<ArticoliDto>(elencoArticoli);
        }

        [HttpGet]
        public async Task<ArticoliDto> GetArticoloByCodiceAsync(string codiceArticolo)
        {
            return await this._articoliServices.GetArticoloAsync(codiceArticolo);
        }

        [HttpPost]
        public void CreateArticolo([FromBody] ArticoliDto articoloToCreate)
        {
            this._articoliServices.CreateArticolo(articoloToCreate);
        }
    }
}