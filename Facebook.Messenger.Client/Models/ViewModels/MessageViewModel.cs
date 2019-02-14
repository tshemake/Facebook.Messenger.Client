using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Facebook.Messenger.Client.Models.ViewModels
{
    public class MessageViewModel
    {
        [Required]
        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }
    }
}
