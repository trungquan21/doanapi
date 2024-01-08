namespace doanapi.Dto
{
    public class ConstructionDetailsDto
    {
        public int? Id { get; set; }
        public int? IdConstruction { get; set; }
        public int? StartDate { get; set; }
        public string Watersource { get; set; }//nguon nuoc
        public string Method { get; set; }//phuong thuc
        public string Purposes { get; set; }//muc dich
        public string Mode { get; set; } //che do
        //nuoc mat
        public int? ConstructionLevel { get; set; } //cấp công trình
        public double? Wattage { get; set; } //cong suất
        public double? Flow { get; set; } //lưu lượng
        public double? Capacity { get; set; } //dung tích
        public double? BasinArea { get; set; } //diện tích lưu vực
        public double? WaterLevel { get; set; } //mực nước
        public int? PumpNumber { get; set; } //số máy bơm
        public double? IrrigatedArea { get; set; } //diện tích tưới
        public double? AmountRain { get; set; } // lượng mưa
        //nuoc duoi dat
        public double? NumberWell { get; set; } //số giếng 
        public double? Depth { get; set; } // chiều sâu 
        public string ExplorationScale { get; set; } // quy mô thăm dò
        public double? ExplorationArea { get; set; }  //diện tích thăm dò

        //xa thai
        public string DischargeLocation { get; set; }
        public double? KQ { get; set; }  //Hệ số KQ

        public double? KF { get; set; }  //Hệ số KF

        public bool? Deleted { get; set; }
    }
}
