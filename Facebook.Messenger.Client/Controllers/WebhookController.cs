using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json;

namespace Facebook.Messenger.Client.Controllers
{
    public class WebhookController : ApiController
    {
        public static readonly string PAGE_ACCESS_TOKEN = Environment.GetEnvironmentVariable("PAGE_ACCESS_TOKEN");
        public static readonly string VERIFY_TOKEN = Environment.GetEnvironmentVariable("VERIFY_TOKEN");

        // GET api/<controller>
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var queryStrings = Request.GetQueryNameValuePairs().ToDictionary(x => x.Key, x => x.Value);
            var mode = queryStrings["hub.mode"] ?? string.Empty;
            var token = queryStrings["hub.verify_token"] ?? string.Empty;
            var challenge = queryStrings["hub.challenge"] ?? string.Empty;

            if (mode != "subscribe" || token != VERIFY_TOKEN) {
                return new HttpResponseMessage(HttpStatusCode.Unauthorized);
            }
            return new HttpResponseMessage(HttpStatusCode.OK) {
                Content = new StringContent(challenge, Encoding.UTF8, "text/plain")
            };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public async Task<HttpResponseMessage> Post()
        {
            try {
            }
            catch (Exception) {
                return new HttpResponseMessage(HttpStatusCode.BadGateway);
            }

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}