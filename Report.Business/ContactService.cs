using Newtonsoft.Json;
using Report.Business.Dtos.ContactServiceDtos;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Business
{
    public class ContactService : IContactService
    {
        private readonly string ContactServiceHost = "https://localhost:7055";
        public async Task<List<ContactDto>> GetAllByLocation(string location)
        {
            var client = new RestClient($"{ContactServiceHost}/contact/getAllByLocation?location={location}");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            var returnValue = new List<ContactDto>();

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                returnValue = JsonConvert.DeserializeObject<List<ContactDto>>(response.Content);

            return await Task.FromResult(returnValue);
        }
    }
}
