using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SarhSolution.Models;
using SarhSolution.Models.ViewModels;

namespace SarhSolution.Controllers
{
    public class CostxusuController : Controller
    {
        private bdcmp_ccam_sisadmEntities db = new bdcmp_ccam_sisadmEntities();

        public string draw = "";
        public string start = "";
        public string length = "";
        public string sortColumn = "";
        public string sortColumnDir = "";
        public string searchValue = "";
        public int pageSize, skip, recordsTotal;
        // GET: Famxusu
        public ActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public ActionResult IdUsuario(int Usucent)
        {
            List<TableCostxusuViewModel> lst = new List<TableCostxusuViewModel>();

            var draw = Request.Form.GetValues("draw").FirstOrDefault();
            var start = Request.Form.GetValues("start").FirstOrDefault();
            var length = Request.Form.GetValues("length").FirstOrDefault();
            var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
            var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();
            var searchValue = Request.Form.GetValues("search[value]").FirstOrDefault();

            pageSize = length != null ? Convert.ToInt32(length) : 0;
            skip = start != null ? Convert.ToInt32(start) : 0;
            recordsTotal = 0;

            int idUsucent = ConsultarIdsarh(Usucent);
            lst = this.db.Sarh_CentroCostoxUsurio.Where(x => x.usce_Idusucent == idUsucent).Select(x => new TableCostxusuViewModel()
            {
                usce_Idusuario_fk = x.usce_Idusuario_fk,
                usce_Idcentro_fk = x.usce_Idcentro_fk
            }).ToList();

            recordsTotal = lst.Count();

            lst = lst.Skip(skip).Take(pageSize).ToList();

            return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = lst });
        }
        public int ConsultarIdsarh(int Usucent)
        {
            try
            {
                string result = this.db.Sarh_CentroCostoxUsurio.Where(x => x.usce_Idusucent == Usucent).Select(x => x.usce_Idusucent).FirstOrDefault().ToString();
                int conver = (int)Convert.ToInt64(result);
                return conver;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
    }
}