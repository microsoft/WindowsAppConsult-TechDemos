using System;
using System.Collections.Generic;

namespace WinUISample.Models
{
    public class SerieFollowersVM
    {
        public SerieFollowersVM()
        {

        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Followers { get; set; }
        public DateTimeOffset FirstAired { get; set; }
        public string Country { get; set; }
        public string Overview { get; set; }
        public int Runtime { get; set; }
        public string Status { get; set; }
        public string Network { get; set; }
        public string AirTime { get; set; }
        public string ContentRating { get; set; }
        public string ImdbId { get; set; }
        public int TvdbId { get; set; }
        public string Language { get; set; }
        public ImagesSerieVM Images { get; set; }
        public ICollection<GenreVM> Genres { get; set; }
        public DateTime Added { get; set; }
        public DateTime LastUpdated { get; set; }
        public string SlugName { get; set; }
    }
}
