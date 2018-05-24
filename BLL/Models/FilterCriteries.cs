namespace BLL.Models
{
    public class FilterCriteries
    {
        public int[] RAM { get; set; }
        public double[] Camera { get; set; }
        public double[] DisplayDiagonal { get; set; } 
        public int[] MemorySize { get; set; }

        public int minPrice { get; set; } 
        public int maxPrice { get; set; }
    }
}
