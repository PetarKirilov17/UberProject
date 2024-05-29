using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Uber.Core.Contracts;
using Uber.Core.OpenRouteService.Models;
using Uber.Infrastructure.Data.Models;

namespace Uber.Core.OpenRouteService
{
    // TODO : ask if it is good to make it singleton
    public class MatrixHandler
    {
        private MatrixResultModel? matrix { get; set; }
        private async Task LoadMatrix(MatrixInputModel inputModel)
        {
            var baseAddress = new Uri("http://localhost:8080"); // , http://localhost:8080, https://api.openrouteservice.org

            using (var httpClient = new HttpClient { BaseAddress = baseAddress })
            {
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "application/json, application/geo+json, application/gpx+xml, img/png; charset=utf-8");
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
                httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", "5b3ce3597851110001cf62486f32482d652d42efa0bcaf7cc557e98c");

                string inputJson = JsonConvert.SerializeObject(inputModel);

                using (var content = new StringContent(inputJson, Encoding.UTF8, "application/json")) // "{ \"locations\":[[23.2790,42.7183],[24.1885,42.6976],[23.5985,42.6665]], \"sources\": [0]}"
                {
                    using (var response = await httpClient.PostAsync("/ors/v2/matrix/driving-car", content))
                    {
                        string responseData = await response.Content.ReadAsStringAsync();
                        matrix = JsonConvert.DeserializeObject<MatrixResultModel>(responseData);

                        // parse to curl - if needed
                        //var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, "/ors/v2/matrix/driving-car");
                        //httpRequestMessage.Content = content;   
                        //var cUrl = httpClient.GenerateCurlInString(httpRequestMessage);
                    }
                }
            }
        }

        private MatrixInputModel CreateInputModel(List<Driver> freeDrivers, double currentAddressLatitude, double currentAddressLongitude)
        {
            var inputModel = new MatrixInputModel();
            //fill the location of the client
            inputModel.locations
                .Add(new List<double>() 
                {
                    currentAddressLongitude,
                    currentAddressLatitude
                });

            // fill the drivers locations
            for (int i = 0; i < freeDrivers.Count; i++)
            {
                List<double> currLocation = new List<double>()
                {
                    freeDrivers[i].CurrentPosition.Value.X,
                    freeDrivers[i].CurrentPosition.Value.Y,
                };
                inputModel.locations.Add(currLocation);
            }

            // fill the source - zero because we put the client's location first
            inputModel.sources.Add(0);

            return inputModel;
        }

        private int FindIndexOfTheClosestDriver()
        {
            if (matrix == null || matrix.durations == null)
            {
                return -1;
            }
            // matrix.durations is matrix with one row which shows the durations from the source point to all others
            var durationsToDrivers = matrix.durations[0].Skip(1).ToList();
            return durationsToDrivers.FindIndex(d => d == durationsToDrivers.Min());
        }

        public async Task<Driver> GetTheClosestDriver(IDriverService driverService, double currentAddressLatitude, double currentAddressLongitude)
        {
            // 1 Get the Free Drivers
            var freeDrivers = await driverService.GetAllFreeDrivers();
            if (freeDrivers.Count == 0) // no free drivers
            {
                throw new ArgumentException("No free drivers at the moment");
            }

            // 2 Create the InputModel
            var inputModel = CreateInputModel(freeDrivers, currentAddressLatitude, currentAddressLongitude);

            // 3 Load the matrix for the free drivers 
            await LoadMatrix(inputModel);

            // 4 ger the index of the closest driver
            var driverIndex = FindIndexOfTheClosestDriver();

            // 5 return the driver
            if (driverIndex == -1) // driver is not found
            {
                throw new Exception("There is no driver in the area!");
            }
            return freeDrivers[driverIndex];
        }
    }
}
