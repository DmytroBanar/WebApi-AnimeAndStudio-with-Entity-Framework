using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace UnitOfWorkDemo.Core.Models
{
    public class AnimeStudioDetails
    {
        [Key] public int StudioId { get; set; }
        public string StudioName { get; set; }
        public string StudioCountry { get; set; }
        public int StudioNumProjects { get; set; }
        public string StudioMPWork { get; set; }
        [JsonIgnore] public List<AnimeDetails> Anime { get; set; } = new();
    }
}
