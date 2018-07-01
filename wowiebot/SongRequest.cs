using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using Google.Apis.Services;
using System.Text.RegularExpressions;

namespace wowiebot
{
    public class SongRequest
    {
        static YouTubeService youtubeService = new YouTubeService(new BaseClientService.Initializer()
        {
            ApiKey = "AIzaSyB7ju2a_MJKjs3eBKcrcgHfjhRrWq-CTNo",
            ApplicationName = "wowiebot",
        });
        public string title;
        public string uploader;
        public TimeSpan duration;
        public ulong? views;
        public string thumbUrl;
        public string id;
        public string requester;
        public bool? embeddable;

        public SongRequest(string videoId, string whoRequested)
        {
            VideosResource.ListRequest list = youtubeService.Videos.List("snippet,contentDetails,statistics,status");
            requester = whoRequested;
            list.Id = videoId;
            id = videoId;
            VideoListResponse response = list.Execute();
            title = response.Items.First().Snippet.Title;
            uploader = response.Items.First().Snippet.ChannelTitle;
            views = response.Items.First().Statistics.ViewCount;
            thumbUrl = response.Items.First().Snippet.Thumbnails.Default__.Url;
            embeddable = response.Items.First().Status.Embeddable;
            duration = new TimeSpan();
            
            Regex r = new Regex(@"PT((?<hours>\d+)H)?((?<minutes>\d+)M)?((?<seconds>\d+)S)?");
            Match m = r.Match(response.Items.First().ContentDetails.Duration);
            if (m.Groups["hours"].Value != "")
            {
                duration = duration.Add(new TimeSpan(Int32.Parse(m.Groups["hours"].Value), 0, 0));
            }
            if (m.Groups["minutes"].Value != "")
            {
                duration = duration.Add(new TimeSpan(0, Int32.Parse(m.Groups["minutes"].Value), 0));
            }
            if (m.Groups["seconds"].Value != "")
            {
                duration = duration.Add(new TimeSpan(0, 0, Int32.Parse(m.Groups["seconds"].Value)));
            }
        }
    }
}
