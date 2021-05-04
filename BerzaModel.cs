using Newtonsoft.Json;
using System;

namespace Posao
{
    public class BerzaModel
    {
       //properties
        [JsonProperty("tradedatetimegmt")]
        public DateTime? datumVreme { get; set; }
        [JsonProperty("open")]
        public decimal cenaNaOtvaranju { get; set; }
        [JsonProperty("high")]
        public decimal najvisaPostignuta { get; set; }
        [JsonProperty("low")]
        public decimal najnizaPostignuta { get; set; }
        [JsonProperty("close")]
        public decimal prosecnaCenaZatv { get; set; }
        [JsonProperty("volume")]
        public decimal ukupanBrojAkcija { get; set; }


        

        


        //ctor
        public BerzaModel(DateTime? datumVreme, decimal cenaNaOtvaranju, decimal najvisaPostignuta, decimal najnizaPostignuta, decimal ukupanBrojAkcija, decimal prosecnaCena)
        {
            this.datumVreme = datumVreme;
            this.cenaNaOtvaranju = cenaNaOtvaranju;
            this.najvisaPostignuta = najvisaPostignuta;
            this.najnizaPostignuta = najnizaPostignuta;
            this.ukupanBrojAkcija = ukupanBrojAkcija;
            this.prosecnaCenaZatv = prosecnaCena;
        }

        
      
        


    }
}
