using SWAPI.Models.APIModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace SWAPI
{
    public class StarWarsClient
    {
        private readonly HttpClient _client;

        public StarWarsClient(HttpClient client)
        {
            _client = client;
        }


        public async Task<PeopleResponseModel> GetSinglePerson(string id)
        {
            return await GetAsync<PeopleResponseModel>($"/api/people/{id}/");
        }

        public async Task<PlanetResponseModel> GetSinglePlanet(string id)
        {
            return await GetAsync<PlanetResponseModel>($"/api/planets/{id}/");
        }


        private async Task<T> GetAsync<T>(string endPoint)
        {
            // Post    -  Insert    -  Create
            // Get     -  Select    -  Read
            // Put     -  Update    -  Update
            // Delete  -  Delete    -  Delete


            var response = await _client.GetAsync(endPoint);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStreamAsync();

                // var jsonOptions = new JsonSerializerOptions();

                var model = await JsonSerializer.DeserializeAsync<T>(content);

                return model;
            }
            else
            {
                throw new HttpRequestException("Star Wars API returned bad response");
            }
        }
    }
}
