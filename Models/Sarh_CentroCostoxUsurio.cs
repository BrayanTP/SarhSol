//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SarhSolution.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Sarh_CentroCostoxUsurio
    {
        public int usce_Idusucent { get; set; }
        public decimal usce_Idusuario_fk { get; set; }
        public int usce_Idcentro_fk { get; set; }
        public Nullable<decimal> usce_Idoperacion { get; set; }
        public System.DateTime usce_fechacreacion { get; set; }
        public decimal usce_Usucreador { get; set; }
        public System.Guid rowguid { get; set; }
    
        public virtual Sarh_usuario Sarh_usuario { get; set; }
    }
}
