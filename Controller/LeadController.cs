using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Client;
using Microsoft.Xrm.Client.Services;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IFSConsole.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph;
using Entity = Microsoft.Xrm.Sdk.Entity;
using Azure.Core;
using Microsoft.IdentityModel.Protocols;

namespace IFSConsole.Controller
{
    public class LeadController : ApiController
    {
        #region GET method
        [BasicAuthentication]
        public HttpResponseMessage Get()
        {
            LeadClass lead = new LeadClass();
            Address addr = new Address();
            lead.Address = addr;
            return Request.CreateResponse(HttpStatusCode.Created, lead);
        }
        #endregion
        #region POST method
        [BasicAuthentication]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage POST(LeadClass leadClass)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            CrmConnection con = CrmConnection.Parse(ConfigurationManager.ConnectionStrings["CRMConnectionString"].ConnectionString);
            OrganizationService service = null;
            service = new OrganizationService(con);
            try
            {
                Entity lead = new Entity("lead");
                lead["subject"] = leadClass?.Subject;
                lead["firstname"] = leadClass?.FirstName;
                lead["lastname"] = leadClass?.LastName;
                lead["companyname"] = leadClass?.Company;
                lead["websiteurl"] = leadClass?.Website;
                lead["address1_line1"] = leadClass?.Address?.Address_Line1;
                lead["address1_line2"] = leadClass?.Address?.Address_Line2;
                lead["address1_line3"] = leadClass?.Address?.Address_Line3;
                lead["address1_city"] = leadClass?.Address?.City;
                lead["address1_stateorprovince"] = leadClass?.Address?.State;
                lead["address1_postalcode"] = leadClass?.Address?.Postal_Code;
                lead["address1_country"] = leadClass?.Address?.Country;
                Guid guid = service.Create(lead);
                leadClass.LeadId = guid.ToString();
                return Request.CreateResponse(HttpStatusCode.Created, leadClass);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.OK, ex.Message);
            }
        }
        #endregion
    }
}  


