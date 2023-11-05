using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace UnitOfWorkDemo.Core.Models
{
    public class AnimeDetails
    {
        [Key] public int AnimeId { get; set; }
        public string AnimeName { get; set; }
        public float AnimeScore { get; set; }
        public int AnimeEpisodes { get; set; }
        public string AnimeType { get; set; }
        public string AnimeAuthor { get; set; }
        public int AnimeStudioId { get; set; }

        [JsonIgnore] public AnimeStudioDetails? AnimeStudio { get; set; }
    }
}
