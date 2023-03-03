using YoutubeExplode;
using YoutubeExplode.Videos.Streams;

namespace UrlsManager.Menus
{
    public class YoutubeSearchMenu : Menu
    {
        public YoutubeSearchMenu(Menu parent)
        {
            Description = "Youtube Search Menu";
        }

        public override void Action()
        {
            getVideo();
        }

        public static async Task getVideo()
        {

            var youtube = new YoutubeClient();

            var videoUrl = "https://www.youtube.com/watch?v=hj0TG-bwUYk";

            var video = await youtube.Videos.GetAsync(videoUrl);

            var title = video.Title;

            Console.WriteLine(title);
        }
    }
}
