using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace MultipleForeignRelation.Data.Entities
{
    public class Provider
    {
        public int Id { get; set; }

        [Required]
        public int PrimaryStateId { get; set; }
        public virtual State PrimaryState { get; set; }

        public int? BillingStateId { get; set; }
        public virtual State BillingState { get; set; }

        public int? ShippingStateId { get; set; }
        public virtual State ShippingState { get; set; }
    }

    class ProviderConfig : IEntityTypeConfiguration<Provider>
    {
        public void Configure(EntityTypeBuilder<Provider> entity)
        {
            entity.HasOne(x => x.PrimaryState)
                  .WithMany(x => x.ProvidersPrimary)
                  .IsRequired(true)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(x => x.BillingState)
                  .WithMany(x => x.ProvidersBilling)
                  .IsRequired(false)
                  .OnDelete(DeleteBehavior.SetNull);

            entity.HasOne(x => x.ShippingState)
                  .WithMany(x => x.ProvidersShipping)
                  .IsRequired(false)
                  .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
