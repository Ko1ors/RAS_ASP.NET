namespace RAS_ASP.NET.Models
{
    public class CuisineTotalRecord
    {
        public decimal TotalPrice { get; set; }

        public int TotalDish { get; set; }

        public bool IsEmpty => TotalPrice == 0 && TotalDish == 0; 
    }
}
