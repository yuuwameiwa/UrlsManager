using YoutubeExplode;
using YoutubeExplode.Videos.Streams;


namespace UrlsManager.Managers
{
    public class YoutubeAudioManager
    {
        public static async Task DownloadVideo(string urlInput, string savePath)
        {
            var youtube = new YoutubeClient();

            // Получить данные о видео
            var video = await youtube.Videos.GetAsync(urlInput);

            // Создание манифеста. Манифест - лист со всеми возможными "потоками" видео.
            var streamManifest = await youtube.Videos.Streams.GetManifestAsync(urlInput);

            // Получение только аудио от Манифеста
            var streamInfo = streamManifest.GetAudioOnlyStreams().GetWithHighestBitrate();

            // Получить актуальный поток
            var stream = await youtube.Videos.Streams.GetAsync(streamInfo);

            // Создать путь и название для скачивания
            var outputPath = Path.Combine(savePath, video.Title + ".mp4");
            
            // Скачать
            await youtube.Videos.Streams.DownloadAsync(streamInfo, outputPath);

            // Указать путь куда скачалось аудио
            await Console.Out.WriteLineAsync("Audio has been downloaded to: " + savePath);

        }
    }
}

