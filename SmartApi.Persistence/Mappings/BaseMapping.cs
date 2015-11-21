using System.Data.Entity.ModelConfiguration;
using SmartApi.Shared.Dtos;

namespace SmartApi.Persistence.Mappings
{
    public abstract class BaseMapping<TEntity> : EntityTypeConfiguration<TEntity> where TEntity : DtoBase
    {
        protected BaseMapping(string tableName)
        {
            #region Key
            this.HasKey(t => t.Id);
            #endregion

            #region Table
            this.ToTable(tableName);
            #endregion
        }
    }
}
