using Microsoft.AspNetCore.Mvc;
using Project.Youtube.Services;

namespace Project.Youtube.Controllers
{
    public class IndexController : Controller
    {
        YouTubeAPIClient _youTubeApiClient;
        public IndexController(YouTubeAPIClient youTubeApiClient)
        {
            _youTubeApiClient = youTubeApiClient;
        }
        public IActionResult GetVideoDetails()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetVideoDetails(string videoId, string apiKey)
        {
            if (string.IsNullOrEmpty(videoId) || string.IsNullOrEmpty(apiKey))
            {
                ViewData["Error"] = "Video ID and API Key are required!";
                return View("GetVideoDetails");
            }

            string videoDetails = await _youTubeApiClient.GetVideoDetailsAsync(videoId, apiKey);

            if (videoDetails != null)
            {
                ViewData["VideoDetails"] = videoDetails;
            }
            else
            {
                ViewData["Error"] = "Failed to retrieve video details. Please check your Video ID and API Key.";
            }

            return View("GetVideoDetails");
        }
        public IActionResult GetChannelVideos()
        {
        
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> GetChannelVideos(string channelId, string apiKey)
        {
            string channelDetails = await _youTubeApiClient.GetChannelVideosAsync(channelId, apiKey);

            // Kanalın içerik detaylarına göre playlist ID'sini alın
            string playlistId = ExtractPlaylistIdFromChannelDetails(channelDetails);

            if (!string.IsNullOrEmpty(playlistId))
            {
                string playlistVideos = await _youTubeApiClient.GetPlaylistVideosAsync(playlistId, apiKey);

                // playlistVideos içinde videoların detayları bulunmaktadır
                ViewData["PlaylistVideos"] = playlistVideos;
            }
            else
            {
                ViewData["Error"] = "Failed to retrieve channel videos. Please check your Channel ID and API Key.";
            }

            return View("GetChannelVideos");
        }
        private string ExtractPlaylistIdFromChannelDetails(string channelDetails)
        {
           
            int startIndex = channelDetails.IndexOf("uploads");
            int endIndex = channelDetails.IndexOf("\"", startIndex + 10);

            if (startIndex != -1 && endIndex != -1)
            {
                string playlistId = channelDetails.Substring(startIndex + 10, endIndex - (startIndex + 10));
                return playlistId;
            }

            return null;
        }
    }
}
