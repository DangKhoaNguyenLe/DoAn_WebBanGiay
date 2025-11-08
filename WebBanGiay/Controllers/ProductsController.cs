using DoAn_WebBanGiay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace DoAn_WebBanGiay.Controllers
{
    public class ProductsController : Controller
    {
        private myDbQL_BanGiay db = new myDbQL_BanGiay();
        // GET: Products
        public ActionResult Index(int? danhmucid, string sort, string gia, int page = 1)
        {
            ViewBag.DanhMuc = db.danhMuc.ToList();
            var products = db.sanPham.AsQueryable();

            if (danhmucid != null)
                products = products.Where(p => p.IdDMuc == danhmucid);

            if (!string.IsNullOrEmpty(gia))
            {
                switch (gia)
                {
                    case "duoi1trieu": products = products.Where(p => p.Gia < 1000000); break;
                    case "1-1trieu5": products = products.Where(p => p.Gia >= 1000000 && p.Gia <= 1500000); break;
                    case "1trieu5-2trieu": products = products.Where(p => p.Gia >= 1500000 && p.Gia <= 2000000); break;
                    case "tren2trieu": products = products.Where(p => p.Gia > 5000000); break;
                }
            }
            switch (sort)
            {
                case "tang": products = products.OrderBy(p => p.Gia); break;
                case "giam": products = products.OrderByDescending(p => p.Gia); break;
                default:
                    products = products.OrderBy(p => p.IdSP);
                    break;
            }

            int sl = 8;
            int tong = products.Count();
            int strang = (int)Math.Ceiling((double)tong / sl);
            int slskip = (page - 1) * sl;

            ViewBag.Page = page;
            ViewBag.NoOfPages = strang;

            var pagedProducts = products.Skip(slskip).Take(sl).ToList();

            return View(pagedProducts);
        }

        public ActionResult Detail(int id)
        {
            var product = db.sanPham.FirstOrDefault(p => p.IdSP == id);

            if (product == null)
            {
                return HttpNotFound();
            }
            var images = db.Anh
                           .Where(a => a.IdSP == id)
                           .Select(a => a.ImageURL)
                           .ToList();
            ViewBag.Images = images;
            ViewBag.Sizes = db.Size.ToList();
            ViewBag.SpCungLoai = db.sanPham.Where(p => p.IdDMuc == product.IdDMuc && p.IdSP != id).Take(4).ToList();
            return View(product);
        }

    }
}