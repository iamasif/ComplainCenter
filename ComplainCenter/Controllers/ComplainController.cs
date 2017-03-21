using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ComplainCenter.Models;

namespace ComplainCenter.Controllers
{
    public class ComplainController : Controller
    {
        //
        // GET: /Complain/

        ComplainCenterEntities1 db = new ComplainCenterEntities1();
        public ActionResult Index(int p = 0, int PageSize = 10, string keyword = "", string SortBy = "", bool desc = false)
        {
            List<Complain> complains = null;
            var _total = 0;

            if (String.IsNullOrEmpty(keyword))
            {
                switch (SortBy)
                {
                    case "Title":
                        if (desc)
                            complains = db.Complains.OrderByDescending(x => x.Title).Skip(p * PageSize).Take(PageSize).ToList();
                        else
                            complains = db.Complains.OrderBy(x => x.Title).Skip(p * PageSize).Take(PageSize).ToList();
                        break;

                    case "ComplainDate":
                        if (desc)
                            complains = db.Complains.OrderByDescending(x => x.ComplainDate).Skip(p * PageSize).Take(PageSize).ToList();
                        else
                            complains = db.Complains.OrderBy(x => x.ComplainDate).Skip(p * PageSize).Take(PageSize).ToList();
                        break;
                    default:
                        complains = db.Complains.OrderBy(x => x.Id).Skip(p * PageSize).Take(PageSize).ToList();
                        break;
                }
                _total = db.Complains.Count();

            }

            else
            {
                keyword = keyword.ToLower();

                switch (SortBy)
                {
                    case "ResolvedDate":
                        complains = db.Complains.Where(c => c.Title.ToLower().Contains(keyword))
                            .OrderBy(x => x.ResolvedDate).Skip(p * PageSize).Take(PageSize).ToList();
                        break;

                    case "Title":
                        complains = db.Complains.Where(c => c.Title.ToLower().Contains(keyword))
                            .OrderBy(x => x.Title).Skip(p * PageSize).Take(PageSize).ToList();
                        break;

                    case "ComplainStatusId":
                        complains = db.Complains.Where(c => c.Title.ToLower().Contains(keyword))
                            .OrderBy(x => x.ComplainStatusId).Skip(p * PageSize).Take(PageSize).ToList();
                        break;

                    default:
                        complains = db.Complains.Where(c => c.Title.ToLower().Contains(keyword))
                            .OrderBy(x => x.Id).Skip(p * PageSize).Take(PageSize).ToList();
                        break;

                }
                _total = db.Complains.Count(c => c.Title.ToLower().Contains(keyword));


            }

            ComplainResult result = new ComplainResult();
            result.Complains = complains;
            result.CurrentPage = p;
            result.PageSize = PageSize;
            result.TotalComplains = _total;
            result.Keyword = keyword;


            return View(result);


        }

        public ActionResult Delete(int Id)
        {
            var obj = db.Complains.Find(Id);
            db.Complains.Remove(obj);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
        
    }