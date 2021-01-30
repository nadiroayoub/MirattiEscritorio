using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Miratti
{
    class drvJSON : iDataDriver
    {
        public string origen { get; set; }
        private List<dynamic> datos;
        private List<string> keys;
        private bool error;
        private string errorMsg;
        public bool esLocal { get; set; }
        public drvJSON()
        {
            origen = "";
            datos = new List<dynamic>();
            keys = new List<string>();
            error = false;
            errorMsg = "";
            esLocal = true;
        }
        public bool hayError()
        {
            return error;
        }
        public string getError()
        {
            return errorMsg;
        }
        public int getTotal()
        {
            return datos.Count();
        }
        public int getTotalKeys()
        {
            return keys.Count();
        }
        public dynamic getDato(int indice)
        {
            return datos[indice];
        }
        public string getKey(int indice)
        {
            return keys[indice];
        }
        public bool setDato(int indice, dynamic dato)
        {
            bool res = true;
            //TODO...
            return res;
        }
        public bool saveData()
        {
            bool res = true;
            return res;
        }
        public bool loadData()
        {
            bool res = true;
            string cadena = "";
            if (origen != "")
            {
                if (origen.StartsWith("http"))
                {
                    esLocal = false;
                    using (WebClient wc= new WebClient())
                    {
                        cadena = wc.DownloadString(origen);
                    }
                }
                else
                {
                    esLocal = true;
                    cadena = File.ReadAllText(origen);
                }
                dynamic data = JsonConvert.DeserializeObject(cadena);
                foreach(dynamic item in data)
                {
                    Newtonsoft.Json.Linq.JObject aux = (Newtonsoft.Json.Linq.JObject)item;
                    foreach (Newtonsoft.Json.Linq.JProperty auxItem in aux.Children())
                    {
                        if (!keys.Exists(k => k.Equals(auxItem.Name)))
                        {
                            keys.Add(auxItem.Name);
                        }
                    }
                    datos.Add(item);
                }
            }
            else
            {
                res = false;
            }
            return res;
        }
    }
}
