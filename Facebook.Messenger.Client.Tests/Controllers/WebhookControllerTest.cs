using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Facebook.Messenger.Client;
using Facebook.Messenger.Client.Controllers;
using Facebook.Messenger.Library;
using Facebook.Messenger.Library.Core.Objects;

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
            WebhookController controller = new WebhookController(new FacebookMessenger())
            {
                Request = new HttpRequestMessage
                {
                    RequestUri = new Uri($"http://localhost:49964/api/webhook?hub.verify_token={VERIFY_TOKEN}&hub.challenge={challenge}&hub.mode=subscribe")
                },
                Configuration = new HttpConfiguration()
            };

            // Act
            var response = controller.Get(VERIFY_TOKEN, challenge, "subscribe");

            // Assert
            string result = response.Content.ReadAsStringAsync().Result;
            Assert.AreEqual(challenge, result);
        }
    }

    public class FacebookMessenger : Agent
    {
        public override Task SendTextMessageAsync(MessageRecievedEvent<MessageResponse> message)
        {
            Console.WriteLine($"{message.Recipient.Id}: {message.Message.Text}");
            return Task.FromResult<object>(null);
        }
    }
}
