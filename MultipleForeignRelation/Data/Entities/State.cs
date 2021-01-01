using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace MultipleForeignRelation.Data.Entities
{
    public class State
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Provider> ProvidersPrimary { get; set; } = new List<Provider>();
        public virtual ICollection<Provider> ProvidersBilling { get; set; } = new List<Provider>();
        public virtual ICollection<Provider> ProvidersShipping { get; set; } = new List<Provider>();
    }

    class StateConfig : IEntityTypeConfiguration<State>
    {
        public void Configure(EntityTypeBuilder<State> entity)
        {
            entity.Property(x => x.Name).IsRequired();
            entity.HasIndex(x => x.Name).IsUnique();
        }
    }
}
