namespace Project.Youtube.Services
{
    public class YouTubeAPIClient
    {
        HttpClient _httpClient;
        public YouTubeAPIClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        /*
         *  Video IDleri Vİdeo Urlsinde v= den sonra gelen 11 haneli kısımdır
         *  Kanal ID si 2 Tipdir Biri kanal anasayfasındaki url nin @işaretinden sonra ki kısım diğeride urlnin channel/kısmından sonra gelen kısımdır 
         * 
         * 
         */
        public async Task<string> GetVideoDetailsAsync(string videoId, string apiKey)
        {
            // YouTube API'ye isteği oluşturun
            HttpResponseMessage response = await _httpClient.GetAsync($"videos?part=snippet,contentDetails&id={videoId}&key={apiKey}");

            // Yanıtı okuyun
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                return content;
            }
            else
            {
                // Hata durumunu yönetin
                return null;
            }
        }
        public async Task<string> GetChannelVideosAsync(string channelId, string apiKey)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"channels?part=contentDetails&id={channelId}&key={apiKey}");

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                return content;
            }
            else
            {
                // Hata durumunu yönetin
                return null;
            }
        }
        public async Task<string> GetPlaylistVideosAsync(string playlistId, string apiKey)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"playlistItems?part=snippet&playlistId={playlistId}&key={apiKey}");

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                return content;
            }
            else
            {
                // Hata durumunu yönetin
                return null;
            }
        }
    }
}
