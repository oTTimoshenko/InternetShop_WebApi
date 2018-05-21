namespace BLL.DTO
{
    public class ItemCharacteristicsDTO
    {
        public int ItemCharacteristicId { get; set; }
        public double DisplayDiagonal { get; set; }
        public int RAM { get; set; }
        public int Memory { get; set; } 
        public double Camera { get; set; }

        public ItemDTO Item { get; set; }
    }
}
