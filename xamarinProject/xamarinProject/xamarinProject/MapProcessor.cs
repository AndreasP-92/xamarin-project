using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace xamarinProject
{
    class MapProcessor
    {

        public async Task<Root> LoadPlaces(int id = 1)
        {
            string url = "";

            if (id > 0)
            {
                url = $"https://localhost:44337/CoordInfo/getAllCoordinates";
            }


            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    Root root = await response.Content.ReadAsAsync<Root>();

                    return root;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
