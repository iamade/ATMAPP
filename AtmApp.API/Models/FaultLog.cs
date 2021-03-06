using System;

namespace AtmApp.API.Models
{
    public class FaultLog
    {
        public int Id { get; set; }
      //  public AtmFleet AtmFleet { get; set; }
        public int AtmFleetId {get; set;}
        public string TerminalId { get; set; }
        public string TerminalName { get; set; }    
        public string Vendor { get; set; }
        public string Brand { get; set; }   
        public string NatureOfFault { get; set; }
        public string CustodianName { get; set; }
        public string CustodianNumber { get; set; }
        public DateTime DateLogged { get; set; }
        public DateTime DateResolved { get; set; }
        // public Enum status { 
        //     // [Display(Name = "Pending")]
        //     // Pending = 1,
        //     // [Display(Name = "Resolved")]
        //     // Resolved = 2,
        //     // [Display(Name = "Re-Opened")]
        //     // Re-Opened = 3,

        //  }
        public TimeSpan DefaultDays { get; set; }


    }
}