using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Posao
{
    public class Processor
    {   
        public static async Task<List<BerzaModel>> prikaziBerzu(string symbol)
        {
            //dodavanje odredjenog simbola koji se unosi sa forme u url
            string url = "https://webservice.gvsi.com/query/json/GetDaily/tradedatetimegmt/open/high/low/close/volume?pricesymbol=%22" + symbol + "%22&daysBack=100";
            using (var response = await ApiHelper.client.GetAsync(url).ConfigureAwait(false))
            {
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();

                    //Konvertovanje JSON stringa u listu

                    var result = JsonConvert.DeserializeObject<BerzaResultModel>(json);                  
                    return result.Rezultat.Items;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }

        }
    }
}
