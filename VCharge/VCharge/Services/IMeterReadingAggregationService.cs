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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VCharge.Models;

namespace VCharge.Services
{
    public interface IMeterReadingAggregationService
    {
        IEnumerable<MeterConsumption> GetMonthlyReading();
        IEnumerable<MeterConsumption> GetWeeklyReading();
        IEnumerable<MeterConsumption> GetDailyReading();
        IEnumerable<MeterConsumption> GetReadingByPeriod(DateTime startDate, DateTime endDate);
    }
}
