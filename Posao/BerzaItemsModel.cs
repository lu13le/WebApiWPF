using Newtonsoft.Json;
using System.Collections.Generic;

namespace Posao
{
    public class BerzaItemsModel
    {
        [JsonProperty("items")]
        public List<BerzaModel> Items { get; set; }
    }
}
