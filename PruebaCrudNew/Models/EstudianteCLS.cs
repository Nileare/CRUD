using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using PruebaCrudNew.Models;
using System.Web.Mvc;

namespace PruebaCrudNew.Models
{
    public class EstudianteCLS
    {   
        [Display(Name ="Id Estudiante")]
        public int IdEstudiante { get; set; }

        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Display(Name = "Apellido")]
        public string Apellido { get; set; }

        [Display(Name = "Edad")]
        public string Edad { get; set; }

        [Display(Name = "Dirección")]
        public string Dirección { get; set; }

        public int Bhabilitado { get; set; }
    }
}