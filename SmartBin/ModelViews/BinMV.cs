namespace SmartBin.ModelViews
{
    public class BinMV
    {
        public int BinId { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
    }
    public class BinDetailsMV
    {
        public int BinId { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public List<BinSectionMV> Sections { get; set; }
    }
    public class BinUpdateMV { 
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
    }
}
