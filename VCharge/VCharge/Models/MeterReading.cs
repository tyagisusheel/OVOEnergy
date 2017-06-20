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
using VCharge.Utility;

namespace VCharge.Models
{

    // This is a Main class for MeterReading. This class is used for Read the Daa from input .CSV file
    // File Helper Utility is used for Read the csv file
    [DelimitedRecord(",")]
    [IgnoreEmptyLines()]
    [IgnoreFirst()]
    public class MeterReading
    {
        [FieldTrim(TrimMode.Both)]
        [FieldConverter(typeof(DateConverterUtility))]
        private DateTime _Date;
        public DateTime Date
        {
            get { return _Date; }
            set { _Date = value; }
        }


        [FieldTrim(TrimMode.Both)]
        private double _CumulativeConsumption;
        public double CumulativeConsumption
        {
            get { return _CumulativeConsumption; }
            set { _CumulativeConsumption = value; }
        }

        [FieldHidden]
        private double _Unit;
        public double Unit
        {
            get { return _Unit; }
            set { _Unit = value; }
        }

    }

}