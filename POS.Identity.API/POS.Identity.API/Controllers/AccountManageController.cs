using POS.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace POS.API.Controllers
{
    public class AccountManageController : ApiController
    {
        public HttpResponseMessage Register(RegisterBindingModel model)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:10047/api/Account/Register");

                //HTTP POST
                var postTask = client.PostAsJsonAsync<RegisterBindingModel>("Register", model);

 


                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return Request.CreateResponse(HttpStatusCode.Created, "Register Successful");
                }
            }


            return Request.CreateResponse(HttpStatusCode.NotFound);
        }
    }
}
