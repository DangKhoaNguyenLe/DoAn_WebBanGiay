using DoAn_WebBanGiay.Controllers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;
using System.Web.WebPages.Html;


namespace DoAn_WebBanGiay.Models
{
    public class DbProcess
    {
        myDbQL_BanGiay db;
        public DbProcess()
        {
            db = new myDbQL_BanGiay();
        }

        // HANG
        public List<Hang> getListHang()
        {
            return db.Hang.ToList();
        }

        public Hang getHangById(int? id)
        {
            return db.Hang.FirstOrDefault(t => t.IdHang == id);
        }

        public bool addHang(Hang h)
        {
            if (h != null)
            {
                db.Hang.Add(h);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool UpdateHang(Hang h)
        {
            if (h != null)
            {
                Hang tmp = getHangById(h.IdHang);
                tmp.tenHang = h.tenHang;
                tmp.XuatXu = h.XuatXu;
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteHang(int? id)
        {
            try
            {
                Hang tmp = getHangById(id);
                db.Hang.Remove(tmp);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //----
        public List<danhMuc> getListdanhMuc()
        {
            return db.danhMuc.ToList();
        }

        public danhMuc getDanhMucById(int? id)
        {
            return db.danhMuc.FirstOrDefault(t => t.IdDMuc == id);
        }

        public bool addDanhMuc(danhMuc m)
        {
            if (m != null)
            {
                db.danhMuc.Add(m);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool UpdateDanhMuc(danhMuc dm)
        {
            if (dm != null)
            {
                danhMuc tmp = getDanhMucById(dm.IdDMuc);
                tmp.tenDMuc = dm.tenDMuc;
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteDanhMuc(int? id)
        {
            try
            {
                danhMuc tmp = getDanhMucById(id);
                db.danhMuc.Remove(tmp);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Mau sac
        public List<Mau> getListMau()
        {
            return db.Mau.ToList();
        }
        public Mau getMauById(int? id)
        {
            return db.Mau.FirstOrDefault(t => t.IdMau == id);
        }

        public bool addMau(Mau m)
        {
            if(m != null)
            {
                db.Mau.Add(m);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteMau(int? id)
        {
            if (id != null)
            {
                Mau tmp = getMauById(id);
                db.Mau.Remove(tmp);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool UpdateMau(Mau m)
        {
            if (m != null)
            {
                Mau tmp = getMauById(m.IdMau);
                tmp.maMau = m.maMau;
                tmp.tenMau = m.tenMau;
                db.SaveChanges();
                return true;
            }
            return false;
        }
        //-----

        public List<Size> getListSize()
        {
            return db.Size.ToList();
        }

        public Size getSizeById(int id)
        {
            return db.Size.FirstOrDefault(t =>t.IdSize == id);
        }
        public bool addSize(Size s)
        {
            if (s != null)
            {
                db.Size.Add(s);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteSize(int id)
        {
            try
            {
                Size tmp = getSizeById(id);
                db.Size.Remove(tmp);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;

            }
        }

        public List<sanPhamBienThe> getListsanPhamBienThe()
        {
            return db.sanPhamBienThe.ToList();
        }

        public List<sanPham> getListsanPham()
        {
            return db.sanPham.ToList();
        }

        public sanPham getsanPhamById(int? id)
        {
            return db.sanPham.FirstOrDefault(t => t.IdSP == id);
        }

        public bool DeleteSanPham(int? id)
        {
            try
            {
                sanPham tmp = getsanPhamById(id);
                db.sanPham.Remove(tmp);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Anh> getListAnh()
        {
            return db.Anh.ToList();
        }

    }
}