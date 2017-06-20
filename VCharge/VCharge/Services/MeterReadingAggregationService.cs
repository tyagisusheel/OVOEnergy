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
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Web;
using VCharge.Models;
using VCharge.Repository;

namespace VCharge.Services
{
    public class MeterReadingAggregationService : IMeterReadingAggregationService
    {
        private string _filePath = String.Empty;
        public MeterReadingAggregationService()
        {
            _filePath = ConfigurationManager.AppSettings["FilePath"].ToString();
        }
        public IEnumerable<MeterConsumption> GetDailyReading()
        {
            MeterReadingsRepository MeterReadingsRepository = new MeterReadingsRepository();
            IEnumerable<MeterReading> listMeterReading = MeterReadingsRepository.GetNumberOfUnits(_filePath);
            var ProcessData = listMeterReading.Select((item) => new MeterConsumption { Date = item.Date.ToString("dd-MMM-yyyy"), Unit = item.Unit }).ToList();

            return ProcessData;
        }

        public IEnumerable<MeterConsumption> GetMonthlyReading()
        {
            MeterReadingsRepository MeterReadingsRepository = new MeterReadingsRepository();
            IEnumerable<MeterReading> lstData = MeterReadingsRepository.GetNumberOfUnits(_filePath);

            Dictionary<string, double> DictnProcessData = new Dictionary<string, double>();

            int i = 0;
            string previous = string.Empty;
            string current = string.Empty;
            double value = 0;

            foreach (var item in lstData)
            {
                current = item.Date.ToString("MMM-yyyy");
                if (i >= 1 && current == previous)
                {
                    value = Math.Round((value + item.Unit), 2);
                }
                else
                {
                    if (value > 0)
                        DictnProcessData.Add(previous, value);
                    value = 0;
                }
                i++;
                previous = item.Date.ToString("MMM-yyyy");
            }
            DictnProcessData.Add(previous, value);

            return DictnProcessData.Select(p => new MeterConsumption { Date = p.Key, Unit = p.Value }).ToList();
        }

        public IEnumerable<MeterConsumption> GetWeeklyReading()
        {
            MeterReadingsRepository MeterReadingsRepository = new MeterReadingsRepository();
            Dictionary<string, double> ProcessData = new Dictionary<string, double>();
            IEnumerable<MeterReading> lstData = MeterReadingsRepository.GetNumberOfUnits(_filePath);

            int i = 0;
            int previousWeek = 0;
            int currentWeek = 0;
            string previous = string.Empty;
            double value = 0;

            foreach (var item in lstData)
            {
                CultureInfo currentCulture;

                GetWeekOfYear(out currentWeek, item, out currentCulture);

                var current = item.Date.ToString("MMM-yy") + "/Wk-" + currentWeek;

                if (i >= 1 && currentWeek == previousWeek)
                {
                    value = Math.Round((value + item.Unit), 2);
                }
                else
                {
                    if (value > 0)
                        ProcessData.Add(previous, value);
                    value = 0;
                }
                i++;
                previousWeek = currentCulture.Calendar.GetWeekOfYear(
                                item.Date,
                                currentCulture.DateTimeFormat.CalendarWeekRule,
                                currentCulture.DateTimeFormat.FirstDayOfWeek);
                previous = item.Date.ToString("MMM-yy") + "/Wk-" + currentWeek;
            }

            ProcessData.Add(previous, value);
            return ProcessData.Select(p => new MeterConsumption { Date = p.Key, Unit = p.Value }).ToList();
        }

        private static void GetWeekOfYear(out int currentWeek, MeterReading item, out CultureInfo currentCulture)
        {
            currentCulture = CultureInfo.CurrentCulture;
            currentWeek = currentCulture.Calendar.GetWeekOfYear(
            item.Date,
            currentCulture.DateTimeFormat.CalendarWeekRule,
            currentCulture.DateTimeFormat.FirstDayOfWeek);
        }

        public IEnumerable<MeterConsumption> GetReadingByPeriod(DateTime startDate, DateTime endDate)
        {
            MeterReadingsRepository MeterReadingsRepository = new MeterReadingsRepository();
            IEnumerable<MeterReading> lstData = MeterReadingsRepository.GetNumberOfUnits(_filePath);
            var ProcessData = lstData.Where(x => x.Date >= startDate && x.Date <= endDate).Select((item) => new { Date = item.Date.ToString("dd-MMM-yyyy"), Unit = item.Unit }).ToList();
            return ProcessData.Select(p => new MeterConsumption { Date = p.Date, Unit = p.Unit }).ToList();
        }

        public IEnumerable<MeterConsumption> GetYearlyReading()
        {
            MeterReadingsRepository MeterReadingsRepository = new MeterReadingsRepository();
            IEnumerable<MeterReading> lstData = MeterReadingsRepository.GetNumberOfUnits(_filePath);

            Dictionary<string, double> DictnProcessData = new Dictionary<string, double>();

            int i = 0;
            string previousYear = string.Empty;
            string currentYear = string.Empty;
            double value = 0;

            foreach (var item in lstData)
            {
                currentYear = item.Date.ToString("yyyy");
                if (i >= 1 && currentYear == previousYear)
                {
                    value = Math.Round((value + item.Unit), 2);
                }
                else
                {
                    if (value > 0)
                        DictnProcessData.Add(previousYear, value);
                    value = 0;
                }
                i++;
                previousYear = item.Date.ToString("yyyy");
            }
            DictnProcessData.Add(previousYear, value);

            return DictnProcessData.Select(p => new MeterConsumption { Date = p.Key, Unit = p.Value }).ToList();
        }


    }
}