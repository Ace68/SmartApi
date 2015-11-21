using System.ComponentModel.DataAnnotations.Schema;
using SmartApi.Shared.Dtos;

namespace SmartApi.Persistence.Mappings
{
    public class ArticoliMap : BaseMapping<ArticoliDto>
    {
        public ArticoliMap() :
            base("Art")
        {
            this.HasKey(p => p.CodiceArticolo);

            this.Property(p => p.Id)
                .HasColumnName("id_art")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(p => p.CodiceArticolo)
                .HasColumnName("codart")
                .HasMaxLength(25);

            this.Property(p => p.DescrizioneArticolo)
                .HasColumnName("desart")
                .HasMaxLength(60);

            this.Property(p => p.PrezzoListino)
                .HasColumnName("listino2");

            this.Property(p => p.Marca)
                .HasColumnName("P_CODMARCA")
                .HasMaxLength(20);
        }
    }
}