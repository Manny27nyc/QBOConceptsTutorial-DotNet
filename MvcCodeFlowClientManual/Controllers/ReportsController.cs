﻿
using Intuit.Ipp.OAuth2PlatformClient;
using Intuit.Ipp.Core;
using Intuit.Ipp.Data;
using Intuit.Ipp.QueryFilter;
using Intuit.Ipp.Security;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Net;
using System.Net.Http.Headers;
using Intuit.Ipp.ReportService;

namespace MvcCodeFlowClientManual.Controllers
{
    public class ReportsController : AppController
    {
        // GET: Reports
        public ActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> ReportsWorkflow()
        {
            //Make QBO api calls using .Net SDK
            if (Session["realmId"] != null)
            {
                string realmId = Session["realmId"].ToString();

                try
                {
                    
                    //Initialize OAuth2RequestValidator and ServiceContext
                    ServiceContext serviceContext = base.IntializeContext(realmId);

                    // Create ReportService object
                    ReportService reportService1 = new ReportService(serviceContext);

                    // Add report query parameters 
                    // Run/Read PnL report
                    Report report_pnl = reportService1.ExecuteReport("ProfitAndLoss");

                    ReportService reportService2 = new ReportService(serviceContext);
                    // Add report query parameters 
                    // Run/Read Balance sheet report
                    Report report_balance_sheet = reportService2.ExecuteReport("BalanceSheet");

                    //run year end reports summarize by customer



                    return View("Index", (object)("QBO API calls success!"));
                }
                catch (Exception ex)
                {
                    return View("Index", (object)"QBO API calls Failed!");
                }

            }
            else
                return View("Index", (object)"QBO API call Failed!");
        }
    }
}