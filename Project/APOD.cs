using System.Net;
using System;
using System.IO;
using Newtonsoft.Json;

namespace Project
{
    public class APOD
    {
        string API_KEY = "VXI60DcODhvhmF8waJtjCNBVjtlfv05C4NolwHY0";
        public void TodaysAPOD()
        {
            DateTime today = DateTime.Today;
            GetAPOD(today);
        }
        public void YesterdaysAPOD()
        {
            DateTime yesterday = DateTime.Today.AddDays(-1);
            GetAPOD(yesterday);
        }
        public void GetRandomAPOD()
        {
            Random rand = new Random();
            DateTime start = new DateTime(1995, 6, 16);
            int range = (DateTime.Today - start).Days;
            DateTime randomDate = start.AddDays(rand.Next(range));
            GetAPOD(randomDate);
        }
        public void GetAPOD(DateTime APODdate)
        {
            string url = $"https://api.nasa.gov/planetary/apod?api_key={API_KEY}&date={APODdate.ToString("yyyy-MM-dd")}";
            WebClient client = new WebClient();
            string json = client.DownloadString(url);
            dynamic? data = JsonConvert.DeserializeObject(json);
            Console.WriteLine("Name: " + data.title);
            Console.WriteLine("In Image URL: " + data.url);
            DownloadAPOD(data, "APODfiles");
        }
        public void DownloadAPOD(dynamic data, string folderName)
        {
            string imageUrl = data.url;
            string date = data.date;
            string imageName = date + ".jpg";
            string year = date.Substring(0, 4);
            string month = date.Substring(5, 2);
            string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), folderName, year, month);
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            string filePath = Path.Combine(folderPath, imageName);
            using (WebClient client = new WebClient())
            {
                client.DownloadFile(imageUrl, filePath);
            }
        }
    }
}