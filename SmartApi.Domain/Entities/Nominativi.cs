using System;
using SmartApi.Domain.Abstracts;

namespace SmartApi.Domain.Entities
{
    public class Nominativi : EntityBase
    {
        private string _ragioneSociale;

        protected Nominativi()
        { }

        #region ctor
        internal static Nominativi CreateNominativo(string ragioneSociale)
        {
            var nominativo = new Nominativi(ragioneSociale);

            return nominativo;
        }

        private Nominativi(string ragioneSociale)
        {
            if (string.IsNullOrEmpty(ragioneSociale))
                throw new ArgumentNullException("ragioneSociale", "Ragione Sociale Obbligatoria!");

            this._ragioneSociale = ragioneSociale;
        }
        #endregion
    }
}