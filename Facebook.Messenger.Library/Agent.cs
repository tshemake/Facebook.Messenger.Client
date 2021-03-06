﻿using Facebook.Messenger.Library.Core.Objects;
using Facebook.Messenger.Library.Core.WebhookEvents;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Facebook.Messenger.Library
{
    public abstract class Agent
    {
        public static string PAGE_ACCESS_TOKEN = Environment.GetEnvironmentVariable("PAGE_ACCESS_TOKEN");
        public static string VERIFY_TOKEN = Environment.GetEnvironmentVariable("VERIFY_TOKEN");

        public const string GraphApiUrl = "https://graph.facebook.com";

        /// <summary>
        /// Отправка текста
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public abstract Task<HttpResponseMessage> SendTextMessageAsync(MessageRecievedEvent<MessageResponse> message);

        /// <summary>
        /// Отправка состояния сообщения, отображаемое для пользователя
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public abstract Task<HttpResponseMessage> SendActionAsync(MessageRecievedEvent<IMessage> message);

        /// <summary>
        /// Оформление сообщения
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="message"></param>
        /// <returns></returns>
        public abstract Task<long> MessageCreativesRequestAsync<T>(BroadcastRequest<T> message);

        /// <summary>
        /// Рассылка сообщений нескольким адресатам
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public abstract Task<long> SendBroadcastMessagesAsync(BroadcastMessageRequest message);
    }
}
