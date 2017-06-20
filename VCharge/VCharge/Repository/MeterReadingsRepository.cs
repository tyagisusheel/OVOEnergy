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

using FileHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VCharge.Models;

namespace VCharge.Repository
{
    public class MeterReadingsRepository : IMeterReadingsRepository
    {
        //Get the Metere Reading from File Path
        public IEnumerable<MeterReading> GetMeterReadings(string filePath)
        {
            List<MeterReading> listMeterReading = new List<MeterReading>();
            try
            {
                var engine = new FileHelperEngine<MeterReading>();
                var records = engine.ReadFile(filePath);
                foreach (var record in records)
                {
                    listMeterReading.Add(new MeterReading()
                    {
                        Date = record.Date,
                        CumulativeConsumption = record.CumulativeConsumption
                    });
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return listMeterReading;
        }

        // Get the Number of Units/PerDay  when Pass the File Path. 
        // Unit = (CurrentDay MeterReading - PreviousDay MeterReading)
        public IEnumerable<MeterReading> GetNumberOfUnits(string filePath)
        {
            List<MeterReading> listNumberOfUnits = new List<MeterReading>();   
            try
            {
                MeterReading meterReading = new MeterReading();
                listNumberOfUnits = GetMeterReadings(filePath).OrderBy(x => x.Date).ToList();

                int i = 0;
                double previous = 0;
                double current = 0;
                foreach (MeterReading item in listNumberOfUnits)
                {
                    current = item.CumulativeConsumption;
                    if (i >= 1)
                    {
                        double unit = current - previous;
                        //item.Unit = Math.Round(unit, 2);
                        item.Unit = Math.Round(unit, 2)> 0 ? Math.Round(unit, 2) : 0;
                    }
                    i++;
                    previous = item.CumulativeConsumption;
                }
            }
            catch (Exception)
            {
                throw;
            }
           
            return listNumberOfUnits;
        }

    }

}