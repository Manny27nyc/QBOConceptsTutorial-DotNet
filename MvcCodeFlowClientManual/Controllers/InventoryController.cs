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
using Intuit.Ipp.DataService;
namespace MvcCodeFlowClientManual.Controllers
{
    public class InventoryController : AppController
    {
        // GET: Item
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> InventoryWorkflow()
        {
            //Make QBO api calls using .Net SDK
            if (Session["realmId"] != null)
            {
                string realmId = Session["realmId"].ToString();

                try
                {
                    
                    //Initialize ServiceContext
                    ServiceContext serviceContext = base.IntializeContext(realmId);
                    DataService dataService = new DataService(serviceContext);
                    

                    // Add inventory item with initial quantity on hand =10, income account, expense account and asset account to the item
                    //Create Invoice with the above item
                    // Query quantity for the Inventory item


                    
                    return View("Index", (object)("QBO API calls Success!"));

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