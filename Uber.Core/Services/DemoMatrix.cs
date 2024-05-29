using HttpClientToCurl;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Uber.Core.OpenRouteService.Models;
using System.Text.Json;

namespace Uber.Core.Services
{
    public static class DemoMatrix
    {
        public async static void TestMatrix()
        {
            var baseAddress = new Uri("http://localhost:8080"); // , http://localhost:8080, https://api.openrouteservice.org

            using (var httpClient = new HttpClient { BaseAddress = baseAddress })
            {
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "application/json, application/geo+json, application/gpx+xml, img/png; charset=utf-8");
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
                httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", "5b3ce3597851110001cf62486f32482d652d42efa0bcaf7cc557e98c");

                using (var content = new StringContent("{ \"locations\":[[23.2790,42.7183],[24.1885,42.6976],[23.5985,42.6665]], \"sources\": [0]}", Encoding.UTF8, "application/json"))
                {
                    using (var response = await httpClient.PostAsync("/ors/v2/matrix/driving-car", content))
                    {
                        string responseData = await response.Content.ReadAsStringAsync();
                        var data = JsonConvert.DeserializeObject<MatrixResultModel>(responseData);

                        if (data != null && data.durations != null)
                        {
                            var durationsToDrivers = data.durations[0].Skip(1).ToList();
                            var closestDriverIndex = FindIndexOfTheClosestDriver(durationsToDrivers);
                        }


                        // parse to curl - if needed
                        //var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, "/ors/v2/matrix/driving-car");
                        //httpRequestMessage.Content = content;   
                        //var cUrl = httpClient.GenerateCurlInString(httpRequestMessage);
                    }
                }
            }
        }

        private static int FindIndexOfTheClosestDriver(List<double> durations)
        {
            return durations.FindIndex(d => d == durations.Min());
        }
    }
}
