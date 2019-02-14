using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Facebook.Messenger.Client.Infrastructure;
using Facebook.Messenger.Client.Models.ViewModels;
using Facebook.Messenger.Library;
using Facebook.Messenger.Library.Core.Objects;
using Facebook.Messenger.Library.Core.WebhookEvents;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Facebook.Messenger.Client.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebhookController : ControllerBase
    {
        private readonly ILogger<WebhookController> _logger;

        public WebhookController(ILogger<WebhookController> logger)
        {
            _logger = logger;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get(
            [FromQuery(Name = "hub.verify_token")] string token,
            [FromQuery(Name = "hub.challenge")] string challenge,
            [FromQuery(Name = "hub.mode")] string mode)
        {
            if (mode != "subscribe" || token != Agent.VERIFY_TOKEN)
            {
                return Unauthorized();
            }

            _logger.LogInformation($"WEBHOOK_VERIFIED");

            return Ok(challenge);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] string body)
        {
            try
            {
                Event webhookEvent = JsonConvert.DeserializeObject<Event>(body);

                switch (webhookEvent.Entity)
                {
                    case Types.Topics.PAGE:
                        await EventFeedAsync(webhookEvent.Entries);
                        break;
                    default:
                        return NotFound();
                }
            }
            catch (Exception)
            {
                return Ok("EVENT_RECEIVED");
            }

            return Ok("EVENT_RECEIVED");
        }

        [Route("Received")]
        public async Task<IActionResult> PostReceivedMessages(MessageRecievedEvent<MessageResponse> message)
        {
            try
            {
                await SendTextMessage(message);
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex.Message);
                return StatusCode(502);
            }
            return Ok("EVENT_RECEIVED");
        }

        private async Task ReceivedMessage(Messaging messaging)
        {
            var senderId = messaging.Sender.Id;
            var recipientId = messaging.Recipient.Id;
            var timeOfMessage = messaging.Timestamp;

            var message = messaging.Message;

            _logger.LogInformation($"Sender PSID: {senderId}");

            if (!string.IsNullOrWhiteSpace(message.Text))
            {
                await SendTextMessage(new MessageRecievedEvent<MessageResponse> {
                    Recipient = new Recipient {
                        Id = messaging.Sender.Id
                    },
                    Message = new MessageResponse {
                        Text = message.Text
                    }
                });
            }
        }

        private async Task SendTextMessage(MessageRecievedEvent<MessageResponse> message)
        {
            //await _service.SendTextMessageAsync(message).ContinueWith(responseTask => {
            //    _logger.Info(responseTask.IsFaulted
            //                     ? $"Unable to send message: {responseTask.Exception?.InnerException.Message}"
            //                     : "message sent!");
            //});
        }

#pragma warning disable 1998
        private async Task ReceivedMessageDelivery(MessageDelivery messageDelivery)
        {
            _logger.LogInformation($"{messageDelivery.Mids.Count} messages that were delivered");
        }
#pragma warning restore 1998

#pragma warning disable 1998
        private async Task ReceivedMessageRead(MessageRead messageRead)
        {
            _logger.LogInformation($"All messages that were sent before {messageRead.Watermark} this timestamp were read");
        }
#pragma warning restore 1998

        private async Task EventFeedAsync(ICollection<Entry> entries)
        {
            foreach (var pageEntry in entries)
            {
                var pageId = pageEntry.Id;
                var timeOfEvent = pageEntry.Time;
                foreach (Messaging message in pageEntry.Messages)
                {
                    await MessagingEntry.Match(message, ReceivedMessage, ReceivedMessageDelivery,
                        ReceivedMessageRead);
                }
            }
        }
    }
}
