// ===============================
// AUTHOR           : Susheel Tyagi
// CREATE DATE      : 12/06/2017
// PURPOSE          : Demo Application for Know the Energy Consumption
// SPECIAL NOTES    : This application has been implemented by using C#, ASP.Net Web API, MVC, AJAX Control,Bootstrap,
//                    FileHelper library and JQuery. For Chart display used the “Google Column Chart”.
// ===============================
// Change History: 1.1
//
//==================================

using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VCharge.Services;

namespace VCharge.Controllers
{
    // ASP.NET Web API's for get the energy consumption details by API coppand
    public class VChargeController : ApiController
    {
        MeterReadingAggregationService service = new MeterReadingAggregationService();

        // http://localhost:56782/api/GetDailyReading
        [Route("api/GetDailyReading")]
        public IHttpActionResult GetDailyReading() // Implemented response Type by IHttpActionResult
        {
            try
            {
                var listData = service.GetDailyReading();
                if (listData == null)
                {
                    return Content(HttpStatusCode.NotFound, "Record not found");
                }
                else
                {
                    return Ok(listData);
                }
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        //http://localhost:56782/api/GetWeeklyReading
        [Route("api/GetWeeklyReading")]
        public HttpResponseMessage GetWeeklyReading() // Implemented response Type by HttpResponseMessage
        {
            try
            {
                var listData = service.GetWeeklyReading();
                if (listData == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Record not found");
                }
                return Request.CreateResponse(HttpStatusCode.OK, listData);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.ExpectationFailed, ex.Message);
            }
        }

        //http://localhost:56782/api/GetMonthlyReading
        [Route("api/GetMonthlyReading")]
        public IHttpActionResult GetMonthlyReading()
        {
            try
            {
                var listData = service.GetMonthlyReading();
                if (listData == null)
                {
                    return Content(HttpStatusCode.NotFound, "Record not found");
                }
                else
                {
                    return Ok(listData);
                }
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.ExpectationFailed, ex.Message);
            }
        }

        //http://localhost:56782/api/GetYearlyReading
        [Route("api/GetYearlyReading")]
        public IHttpActionResult GetYearlyReading()
        {
            try
            {
                var listData = service.GetYearlyReading();
                if (listData == null)
                {
                    return Content(HttpStatusCode.NotFound, "Record not found");
                }
                else
                {
                    return Ok(listData);
                }
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.ExpectationFailed, ex.Message);
            }
        }
        
        //http://localhost:56782/api/GetReadingByPeriod/2016-01-04/2016-03-25
        [Route("api/GetReadingByPeriod/{startDate}/{endDate}")]
        public IHttpActionResult GetReadingByPeriod(string startDate, string endDate)
        {
            try
            {
                DateTime sDate = DateTime.Parse(startDate);
                DateTime eDate = DateTime.Parse(endDate);

                if (sDate < eDate)
                {
                    var listData = service.GetReadingByPeriod(sDate, eDate);
                    if (listData == null)
                    {
                        return Content(HttpStatusCode.NotFound, "Record not found");
                    }
                    else
                    {
                        return Ok(listData);
                    }
                }
                else
                {
                    return Content(HttpStatusCode.BadRequest, "startDate is greater than endDate");
                }
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.ExpectationFailed, ex.Message);
            }
        }
    }
}
