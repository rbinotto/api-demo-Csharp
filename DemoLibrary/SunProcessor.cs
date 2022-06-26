using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary
{
    public class SunProcessor
    {
        public static async Task<SunModel> LoadSunInformation(int comicNumber = 0)
        {
            string url = "https://api.sunrise-sunset.org/json?lat=-30.03&long=-51.23&date=today";

            using (HttpResponseMessage reponse = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (reponse.IsSuccessStatusCode)
                {
                    SunResultModel result = await reponse.Content.ReadAsAsync<SunResultModel>();

                    return result.Results;
                }
                else
                {
                    throw new Exception(reponse.ReasonPhrase);
                }
            }
        }
    }
}
