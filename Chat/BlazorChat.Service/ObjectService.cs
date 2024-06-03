using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace BlazorChat.Service
{
    public class ObjectService<T, CreateDto, UpdateDto> : IObjectService<T, CreateDto, UpdateDto> where T : class where CreateDto : class where UpdateDto : class
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;
        private string _endpoint;
        private List<T> objects;
        public ObjectService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }
        public void SetEndpoint(string endpoint)
        {
            _endpoint = endpoint;
        }
        public async Task CreateObject(CreateDto obj)
        {
            await _http.PostAsJsonAsync($"api/{_endpoint}/add", obj);
            _navigationManager.NavigateTo($"{_endpoint}/list");
        }

        public async Task DeleteObject(Guid id)
        {
            await _http.DeleteAsync($"api/{_endpoint}/delete/{id}");
            _navigationManager.NavigateTo($"{_endpoint}/list");
        }

        public async Task<T> GetObjectById(Guid id)
        {
            var result = await _http.GetAsync($"api/{_endpoint}/{id}");

            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return await result.Content.ReadFromJsonAsync<T>();
            }
            return null;
        }

        public async Task<List<T>> GetObjects()
        {
            try
            {
                var result = await _http.GetFromJsonAsync<List<T>>($"api/{_endpoint}/list");
                if (result != null)
                {
                    objects = result;
                }
                else
                {
                    Console.WriteLine("Response is null.");
                }
                Console.WriteLine(_http.BaseAddress);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching {_endpoint}: {ex.Message}");
            }
            return objects;
        }

        public async Task UpdateObject(UpdateDto obj, Guid id)
        {
            await _http.PutAsJsonAsync($"api/{_endpoint}/update/{id}", obj);
            _navigationManager.NavigateTo($"{_endpoint}/list");
        }
    }
}
