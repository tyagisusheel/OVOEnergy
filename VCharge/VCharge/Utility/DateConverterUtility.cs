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
using System.Web;
using FileHelpers;
using System.Globalization;


namespace VCharge.Utility
{
    class DateConverterUtility : ConverterBase
    {
        public override object StringToField(string inputDate)
        {
            if (string.IsNullOrEmpty(inputDate) || inputDate == "00000000")
            {
                return null;
            }
            return ConvertStringToDateTime(inputDate);
        }
        public static DateTime ConvertStringToDateTime(string inputDate)
        {
            DateTime dt = DateTime.ParseExact(inputDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            return dt;
        }

        protected override bool CustomNullHandling
        {
            get { return true; }
        }
    }
}