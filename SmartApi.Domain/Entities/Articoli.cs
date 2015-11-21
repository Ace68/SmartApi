using SmartApi.Domain.Abstracts;

namespace SmartApi.Domain.Entities
{
    public class Articoli : EntityBase
    {
        public string CodiceArticolo { get; set; }
        public string DescrizioneArticolo { get; set; }
        public string Marca { get; set; }
        public double PrezzoListino { get; set; }
        public bool Ecommerce { get; set; }
    }
}
