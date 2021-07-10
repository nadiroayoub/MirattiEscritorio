using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Miratti
{
    class ConfigAjustes
    {
        // Config page
        public string lang { get; set; }
        public  Brush textoBlocksColor { get; set; } //color textBlocks 
        //public Color fondo { get; set; }
        public Brush botonesColor { get; set; }

        public ConfigAjustes()
        {
            lang = "es";
            //textoBlocksColor = System.dra;
            ////fondo = SystemColors.ControlLightLight;
            //botonesColor = botonColor;


        }
    }
}
