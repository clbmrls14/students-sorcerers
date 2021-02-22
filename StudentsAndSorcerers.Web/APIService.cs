using StudentsAndSorcerers.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace StudentsAndSorcerers.Web
{
    public class APIService
    {
        private readonly HttpClient httpClient;
        public APIService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<Classroom>> GetClassroomsAsync()
        {
            return await httpClient.GetFromJsonAsync<List<Classroom>>("api/classroom/getclassrooms");
        }
    }
}
