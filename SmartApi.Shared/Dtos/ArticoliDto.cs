namespace SmartApi.Shared.Dtos
{
    public class ArticoliDto : DtoBase
    {
        public string CodiceArticolo { get; set; }
        public string DescrizioneArticolo { get; set; }
        public string Marca { get; set; }
        public decimal PrezzoListino { get; set; }
        public bool Ecommerce { get; set; }
    }
}
