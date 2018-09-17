using AirtableWeb.Models;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AirtableWeb
{
    public static class AirtableHandler
    {
        private const string TOKEN = "?api_key=keymfVytNBorTUSPJ";
        private const string airtableUrl = "https://api.airtable.com/v0/appJJJz0VitjPDxfw/";
        private const string choresTable = "Chores";
        private const string recordsTables = "Records";

        public async static Task<ChoreRootObject> GetChores()
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(airtableUrl + choresTable + TOKEN);
                var stringJson = await response.Content.ReadAsStringAsync();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var chores = JsonConvert.DeserializeObject<ChoreRootObject>(stringJson);
                    return chores;
                }
            }

            return null;
        }

        public async static Task<RecordsRootObject> GetRecords()
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(airtableUrl + recordsTables + TOKEN);
                var stringJson = await response.Content.ReadAsStringAsync();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var records = JsonConvert.DeserializeObject<RecordsRootObject>(stringJson);
                    return records;
                }
            }

            return null;
        }

        public static void SendRecord(RecordFields recordFields)
        {
            using (var client = new HttpClient())
            {
                var stringJson = "{ \"fields\":" + JsonConvert.SerializeObject(recordFields) + "}";
                var content = new StringContent(stringJson, Encoding.UTF8, "application/json");
                var url = airtableUrl + recordsTables + TOKEN;

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    streamWriter.Write(stringJson);
                    streamWriter.Flush();
                    streamWriter.Close();
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    System.Console.WriteLine("Record sent.");
                }
            }
        }
    }
}
