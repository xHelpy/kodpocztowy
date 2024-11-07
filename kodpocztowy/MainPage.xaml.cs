
using Microsoft.Maui.Graphics.Text;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace kodpocztowy
{
    public partial class MainPage : ContentPage
    {
        public class postCode
        {
            [JsonPropertyName("post code")]
            public string? post_code { get; set; }
            public string? country { get; set; }
            [JsonPropertyName("country abbreviation")]
            public string? country_abbreviation { get; set; }
            public IList<Place> places { get; set; }
        }
        public class Place
        {
            [JsonPropertyName("place name")]
            public string place_name { get; set; }
            public string? longitude { get; set; }
            public string? state { get; set; }
            [JsonPropertyName("state abbreviation")]
            public string? state_abbreviation { get; set; }
            public string? latitude { get; set; }   
        }



        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            string json;
            string url = "https://api.zippopotam.us/us/90210";
            using (var webClient = new WebClient())
            {
                json = webClient.DownloadString(url);
            }
            postCode data = JsonSerializer.Deserialize<postCode>(json);


            Test.Text = data.places[0].place_name;
        }
    }

}
