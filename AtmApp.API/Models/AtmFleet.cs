namespace AtmApp.API.Models
{
    public class AtmFleet
    {
        public int Id { get; set; }
        public string TerminalId { get; set; }
        public string TerminalName { get; set; }
        public string Ip { get; set; }
        public string Gateway { get; set; }
        public string Brand { get; set; }
        public string Vendor { get; set; }
        public string Region { get; set; }
        public string Location { get; set; }
        public string BranchCode { get; set; }
        public string RegionalPersonnel { get; set; }


    }
}