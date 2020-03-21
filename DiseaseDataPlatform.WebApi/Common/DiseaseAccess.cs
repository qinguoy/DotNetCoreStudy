using DiseaseDataPlatform.WebApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace DiseaseDataPlatform.WebApi.Common
{
    public class DiseaseAccess
    {
        private IHttpClientFactory _clientFactory = null;
        public DiseaseAccess(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<DiseaseResponse> GetDisease()
        {
            string url = @"https://view.inews.qq.com/g2/getOnsInfo?name=disease_h5";
            var httpClient = _clientFactory.CreateClient();

            //HttpContent content = new StringContent(requestString);
            // MultipartFormDataContent =》multipart/form-data 
            //FormUrlEncodedContent =》application/x-www-form-urlencoded 
            //StringContent =》application/json等 
            //StreamContent =》binary
            //content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
            var response = await httpClient.GetAsync(url);
            string responseString = await response.Content.ReadAsStringAsync();
            //string responseString = RestClientHelper.PostByRestClient(url, requestString);

            return JsonUtility.Deserialize<DiseaseResponse>(responseString);

        }
    }
}
