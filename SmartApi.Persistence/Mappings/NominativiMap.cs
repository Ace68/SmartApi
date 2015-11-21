using SmartApi.Shared.Dtos;

namespace SmartApi.Persistence.Mappings
{
    public class NominativiMap : BaseMapping<NominativiDto>
    {
        public NominativiMap()
            : base("Nominativi")
        {
            this.Property(t => t.Id)
                .HasColumnName("NominativoId")
                .IsRequired();

            this.Property(t => t.RagioneSociale)
                .HasMaxLength(50)
                .HasColumnName("RagioneSociale");
        }
    }
}