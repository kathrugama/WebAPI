using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class DetallesCompu
    {
        public int Codigo {get; set;}
        public string Tipo_de_Computadora { get; set; }
        public string Procesador { get; set; }
        public string Memoria_RAM { get; set; }
        public string Tipo_de_disco_duro { get; set; }
        public string Almacenamiento { get; set; }
    }
}