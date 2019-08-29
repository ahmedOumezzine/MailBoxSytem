using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MailBoxSytem.Controllers
{
    public class MailBoxController : Controller
    {
        private MailBoxSytem.Models.ApplicationDbContext dbContext = new Models.ApplicationDbContext();
        // GET: MailBox
        public ActionResult Index()
        {
            return View();
        }


        #region Template

        public ActionResult ListTemplates()
        {
            var list = dbContext.templates.ToList();
            return View(list);
        }
        public ActionResult CreateTemplate()
        {
            return View(new MailBoxSytem.Models.Template());
        }

         [HttpPost]
        public ActionResult CreateTemplate(MailBoxSytem.Models.Template template)
        {
            if (!ModelState.IsValid)
            {
                return View(template);

            }
            dbContext.templates.Add(template);
            dbContext.SaveChanges();
            dbContext.TemplateDetails.Add(new Models.TemplateDetails()
            {
                Body = "",
                Subject = "",
                TemplateId = template.Id

            }); ;
            dbContext.SaveChanges();
            return RedirectToAction("ListTemplates");
        }
        public ActionResult UpdateTemplate(Guid id)
        {
            var list = dbContext.templates.Where(x=>x.Id==id).FirstOrDefault();
            return View(list);
        }
        [HttpPost]
        public ActionResult UpdateTemplate(MailBoxSytem.Models.Template template)
        {
            if (!ModelState.IsValid)
            {
                return View(template);

            }
            dbContext.templates.Attach(template);
            dbContext.Entry(template).State = EntityState.Modified;
            dbContext.SaveChanges();
            return RedirectToAction("ListTemplates");
        }
        public ActionResult DeleteTemplate(Guid id)
        {
            var list = dbContext.templates.Where(x => x.Id == id).FirstOrDefault();
            return View(list);
        }
        [HttpPost]
        public ActionResult DeleteTemplate(MailBoxSytem.Models.Template template)
        {
            return View();
        }

        public ActionResult ListParameters(Guid id)
        {
            ViewBag.TemplateId = id;
            var list = dbContext.Parameters.Where(x => x.TemplateId == id).ToList();
            return View(list);
        }
        public ActionResult CreateParameters(Guid id)
        {
            return View( new MailBoxSytem.Models.Parameters() { TemplateId= id });
        }
        [HttpPost]
        public ActionResult CreateParameters(MailBoxSytem.Models.Parameters parameters)
        {
            if (!ModelState.IsValid)
            {
                return View(parameters);

            }
            dbContext.Parameters.Add(parameters);
            dbContext.SaveChanges();
            return RedirectToAction("ListParameters",new { id =parameters.TemplateId});
        }
        public ActionResult DeleteParameters(Guid id)
        {
            var list = dbContext.Parameters.Where(x => x.Id == id).FirstOrDefault();
            return View(list);
        }
        [HttpPost]
        public ActionResult DeleteParameters(MailBoxSytem.Models.Parameters parameters)
        {
            return View();
        }
        
        public ActionResult TemplateDetails(Guid TemplateId)
        {
            var TemplateDetail = dbContext.TemplateDetails.Include("Template").Include("Template.Parameters").Include("Layout").Where(x => x.TemplateId == TemplateId).FirstOrDefault();
            return View(TemplateDetail);
        }
        [HttpPost]
        public ActionResult TemplateDetails(MailBoxSytem.Models.TemplateDetails templateDetails)
        {
            if (!ModelState.IsValid)
            {
                return View(templateDetails);

            }
            dbContext.TemplateDetails.Attach(templateDetails);
            dbContext.Entry(templateDetails).State = EntityState.Modified;
            dbContext.SaveChanges();
            return RedirectToAction("ListTemplates");
        }

        #endregion

        #region Layouts

        public ActionResult ListLayout()
        {
            var list = dbContext.Layouts.ToList();
            return View(list);
        }

        public ActionResult CreateLayout()
        {
            return View(new MailBoxSytem.Models.Layout());
        }
        [HttpPost]
        public ActionResult CreateLayout(MailBoxSytem.Models.Layout layout)
        {
            return View();
        }

        public ActionResult UpdateLayout()
        {
            return View();
        }
        public ActionResult UpdateLayout(MailBoxSytem.Models.Layout layout)
        {
            return View();
        }

        public ActionResult DeleteLayout()
        {
            return View();
        }
      


        #endregion
    }
}