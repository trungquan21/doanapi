namespace doanapi.Dto
{
    public class ConstructionDetailsDto
    {
        public int Id { get; set; }
        public int? IdConstruction { get; set; }
        public string MiningMode { get; set; }
        public string MiningMethod { get; set; }
        public string MiningPurposes { get; set; }
        public string ExploitedWater { get; set; }
        //nuoc mat
        public int? MachineCapacity { get; set; }
        public double? FlowMax { get; set; }
        public double? FlowTT { get; set; }
        public double? MNC { get; set; }
        public double? MNDL { get; set; }
        public double? MNDBT { get; set; }
        public double? MNCNTL { get; set; }
        //nuocduoidat
        public int? NumberOfExploitation { get; set; }
        public int? PracticeTime { get; set; }
        //xa thai
        public string WastewaterReceiving { get; set; }
        public string DischargeLocation { get; set; }

        public bool? Deleted { get; set; }
    }
}
