using System;
using System.Net;
using Rage;

namespace YourPlugin.Web
{
    internal static class WebDownloader
    {        
        public static string DownloadString(string url, out bool success)
        {
            WebClient client = new WebClient();
            string result;
            try
            {
                result = client.DownloadString(url);
                success = true;
                return result;
            }
            catch (Exception ex)
            {
                if (ex is WebException)
                {
                    Game.LogTrivial($"An error happened when downloading the contents from the following URL: {url}. Make sure you have an active internet connection & a browser set as default.");
                }
                else
                {
                    Game.LogTrivial($"An error happened when downloading the contents from the following URL: {url}. Exception details: {ex}");
                }
                success = false;
                return string.Empty;
            }
        }
    }
}
