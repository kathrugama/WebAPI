using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class DetallesCompu
    {
        public int codigo {get; set;}
        public string tipo_de_Computadora { get; set; }
        public string procesador { get; set; }
        public string memoria_RAM { get; set; }
        public string tipo_de_disco_duro { get; set; }
        public string almacenamiento { get; set; }
    }
}