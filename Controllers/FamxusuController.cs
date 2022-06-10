using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SarhSolution.Models;
using SarhSolution.Models.ViewModels;

namespace SarhSolution.Controllers
{
    public class FamxusuController : Controller
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
        public ActionResult IdUsuario(string cedula)
        {
            List<TableFamxusuViewModel> lst = new List<TableFamxusuViewModel>();

            var draw = Request.Form.GetValues("draw").FirstOrDefault();
            var start = Request.Form.GetValues("start").FirstOrDefault();
            var length = Request.Form.GetValues("length").FirstOrDefault();
            var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
            var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();
            var searchValue = Request.Form.GetValues("search[value]").FirstOrDefault();

            pageSize = length != null ? Convert.ToInt32(length) : 0;
            skip = start != null ? Convert.ToInt32(start) : 0;
            recordsTotal = 0;

            int idfamiliar = ConsultarIdsarh(cedula);
            lst =  this.db.Sarh_familiarxusuario.Where(x => x.id_familiar_pk == idfamiliar).Select(x => new TableFamxusuViewModel()
            {
                fam_idUsuario_fk = x.fam_idUsuario_fk,
                fam_NombreCompleto = x.fam_NombreCompleto,
                fam_DocumentoFamiliar = x.fam_DocumentoFamiliar,
                fam_Parentesco_Familiar = x.fam_Parentesco_Familiar
            }).ToList();

            recordsTotal = lst.Count();

            lst = lst.Skip(skip).Take(pageSize).ToList();

            return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = lst });
        }
        public int ConsultarIdsarh(string cedula)
        {
            try
            {
                string result = this.db.Sarh_familiarxusuario.Where(x => x.fam_DocumentoFamiliar == cedula).Select(x => x.id_familiar_pk).FirstOrDefault().ToString();
                int conver = (int)Convert.ToInt64(result);
                return conver;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
        [HttpPost]
        public ActionResult Json()
        {
            List<TableFamxusuViewModel> lst = new List<TableFamxusuViewModel>();

            var draw = Request.Form.GetValues("draw").FirstOrDefault();
            var start = Request.Form.GetValues("start").FirstOrDefault();
            var length = Request.Form.GetValues("length").FirstOrDefault();
            var sortColumn = Request.Form.GetValues("columns["+ Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
            var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();
            var searchValue = Request.Form.GetValues("search[value]").FirstOrDefault();

            pageSize = length != null ? Convert.ToInt32(length) : 0;
            skip = start != null ?Convert.ToInt32(start) : 0;
            recordsTotal = 0;

            lst = (from d in db.Sarh_familiarxusuario
                   where d.fam_DocumentoFamiliar.Contains(searchValue)
                  select new TableFamxusuViewModel

                  {
                      fam_idUsuario_fk = d.fam_idUsuario_fk,
                      fam_NombreCompleto = d.fam_NombreCompleto,
                      fam_DocumentoFamiliar = d.fam_DocumentoFamiliar,
                      fam_Parentesco_Familiar = d.fam_Parentesco_Familiar
                  }).ToList();

            recordsTotal = lst.Count();

            lst = lst.Skip(skip).Take(pageSize).ToList();

            return Json(new {draw = draw, recordsFiltered= recordsTotal, recordsTotal = recordsTotal, data = lst});
        }
        //[HttpPost]
        //public ActionResult Index(string Documento)
        //{
        //    var documento = from s in db.Sarh_familiarxusuario select s;
        //    if (!string.IsNullOrEmpty(Documento))
        //    {
        //        documento = documento.Where(j => j.fam_DocumentoFamiliar.Contains(Documento));
        //    }
        //    return View(documento);
        //}

        public static string nombreUsuario(int? id_usuario_pk)
        {
            using (var db = new bdcmp_ccam_sisadmEntities())
            {
                return db.Sarh_usuario.Find(id_usuario_pk).us_nombre1;
            }
        }
        
        // GET: Famxusu/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Famxusu/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Famxusu/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Famxusu/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Famxusu/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Famxusu/Delete/5
        public ActionResult Delete(Decimal id_familiar_pk)
        {
            try
            {
                var findFam = db.Sarh_familiarxusuario.Find(id_familiar_pk);
                db.Sarh_familiarxusuario.Remove(findFam);
                db.SaveChanges();

                return RedirectToAction("Index");
            } catch (Exception ex)
            {
                ModelState.AddModelError("", $"error {ex}");
                return View();
            }
            
        }

        
        
    }
}
