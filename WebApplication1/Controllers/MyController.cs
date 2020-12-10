using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    public class MyController
    {

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult FirstPost(string s)
        {
            HttpWebRequest httpReq = (HttpWebRequest)WebRequest.Create("http://localhost:13693");
            httpReq.AllowAutoRedirect = false;

            HttpWebResponse httpRes = (HttpWebResponse)httpReq.GetResponse();
            
            if (httpRes.StatusCode == HttpStatusCode.Moved)
            {
                return this.Content(HttpStatusCode.OK, new { response = "Hello" });
            }
            
            else return this.Content(HttpStatusCode.BadRequest, new { response = "Error" }); ;
            
            // Close the response.
            httpRes.Close(); 
        }

        private ActionResult Content(HttpStatusCode oK, object p)
        {
            throw new NotImplementedException();
        }
    }
    
}
