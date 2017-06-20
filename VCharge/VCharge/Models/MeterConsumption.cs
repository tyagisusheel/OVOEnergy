// ===============================
// AUTHOR           : Susheel Tyagi
// CREATE DATE      : 12/06/2017
// PURPOSE          : Demo Application for Know the Energy Consumption
// SPECIAL NOTES    : This application has been implemented by using C#, ASP.Net Web API, MVC, AJAX Control,Bootstrap,
//                    FileHelper library and JQuery. For Chart display used the “Google Column Chart”.
// ===============================
// Change History: 1.0
//
//==================================


namespace VCharge.Models
{
    //This Class used as Response to HTTPGet client request
    public class MeterConsumption
    {
        public string Date { get; set; }
        public double Unit { get; set; }
    }
}