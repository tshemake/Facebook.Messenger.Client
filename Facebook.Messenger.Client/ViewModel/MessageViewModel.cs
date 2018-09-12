using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Facebook.Messenger.Client.ViewModel
{
    public class MessageViewModel
    {
        [Required]
        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }
    }
}