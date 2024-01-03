namespace doanapi.Dto
{
    public class ConstructionTypeDto
    {
        public int? Id { get; set; }
        public int? IdParent { get; set; }
        public string TypeName { get; set; }
        public string ConstructionTypeCode { get; set; }
        public bool? Deleted { get; set; }
    }
}
