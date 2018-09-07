using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Facebook.Messenger.Client;
using Facebook.Messenger.Client.Controllers;

namespace Facebook.Messenger.Client.Tests.Controllers
{
    [TestClass]
    public class WebhookControllerTest
    {
        public static readonly string VERIFY_TOKEN = Environment.GetEnvironmentVariable("VERIFY_TOKEN");

        [TestMethod]
        public void Verify()
        {
            // Arrange
            string challenge = "CHALLENGE_ACCEPTED";
            WebhookController controller = new WebhookController
            {
                Request = new HttpRequestMessage
                {
                    RequestUri = new Uri($"http://localhost:49964/api/webhook?hub.verify_token={VERIFY_TOKEN}&hub.challenge={challenge}&hub.mode=subscribe")
                },
                Configuration = new HttpConfiguration()
            };

            // Act
            var response = controller.Get();

            // Assert
            string result = response.Content.ReadAsStringAsync().Result;
            Assert.AreEqual(challenge, result);
        }
    }
}
