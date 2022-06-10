using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SarhSolution.Models.ViewModels
{
    public class TableFamxusuViewModel
    {
        public Nullable<decimal> fam_idUsuario_fk { get; set; }
        public string fam_NombreCompleto { get; set; }
        public string fam_DocumentoFamiliar { get; set; }
        public Nullable<int> fam_Parentesco_Familiar { get; set; }
    }
}