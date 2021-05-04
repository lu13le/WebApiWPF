using Newtonsoft.Json;

namespace Posao
{
    public class BerzaResultModel
    {
        [JsonProperty("results")]
        public BerzaItemsModel Rezultat { get; set; }
    }
}
