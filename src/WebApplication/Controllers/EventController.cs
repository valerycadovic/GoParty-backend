using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Newtonsoft.Json;
using Repository.Contexts;
using Repository.Entities;

namespace WebApplication.Controllers
{
    [RoutePrefix("Events")]
    public class EventController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            using (var context = new GoPartyDbContext())
            {
            }
        }
    }
}
