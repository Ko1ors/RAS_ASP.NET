using System.Collections.Generic;


namespace WebApplication.Data.Entities
{

    public class ProductEntity : AbstractEntity
    {
        public virtual string Name { get; set; }
        public virtual double? AvailCount { get; set; }
        public virtual IList<ComponentEntity> Component { get; set; }
        public virtual IList<SupplyEntity> Supply { get; set; }
    }
}
