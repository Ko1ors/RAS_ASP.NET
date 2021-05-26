using System.Collections.Generic;

namespace WebApplication.Data.Entities
{
    public class RestaurantEntity : AbstractEntity
    {
        public virtual string Name { get; set; }

        public virtual string Address { get; set; }

        public virtual string OpenTime { get; set; }

        public virtual string CloseTime { get; set; }

        public virtual int SeatCapacity { get; set; }

        public virtual int CooksSummary { get; set; }

        public virtual IList<CuisineEntity> Cuisines { get; set; }

        public override string ToString()
        {
            return ID + " " + Name;
        }
    }
}
