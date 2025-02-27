﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLTK;
using TracNghiemLTK.Models;
using TracNghiemLTK.Common;

namespace TracNghiemLTK.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			ViewBag.Title = "Home Page";
			return View();
		}
		[HttpPost]
		public ActionResult Index(LoginModel lg)
		{
			LoginData ld = new LoginData();
			var res = ld.CheckLogin(lg.Username, lg.Password);
			if(res == true)
			{
				var student = ld.GetByTen(lg.Username);
				var studentSession = new ThiSinhInfo();
				studentSession.MaThiSinh = student.MaThiSinh;
				studentSession.HoTen = student.HoTen;
				studentSession.Image = student.Image;
				studentSession.MaLop = student.MaLop;
				Session.Add(CommonConstantsStudent.STUDENT_SESSION, studentSession);
				return RedirectToAction("Index", "Default", new { area = "Contest" });
			}
			else
			{
				ModelState.AddModelError("", "Đăng nhập không thành công!");
			}
			return View(lg);
		}
		public ActionResult MaSinhVien()
		{
			ThiSinhData dt = new ThiSinhData();
			var model = dt.ListThiSinh();
			return View(model);
		}
        DeThiData dt = new DeThiData();
        TracNghiemEntities tn = new TracNghiemEntities();
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(ThiSinh entity)
        {
            if (ModelState.IsValid)
            {
                var dao = new ThiSinhData();
                var user = new ThiSinh();
                user.GioiTinh = entity.GioiTinh;
                user.NgaySinh = entity.NgaySinh;
                user.DiaChi = entity.DiaChi;
                user.Image = entity.Image;
                user.Password = entity.Password;
                tn.SaveChanges();


                if (dao.Insert(user) > 0)
                {
                    ViewBag.Success = "Đăng ký thành công!";
                    entity = new ThiSinh();
                }
                else
                {
                    ModelState.AddModelError("", "Đăng ký không thành công!");
                }



            }
            return RedirectToAction("Index", "Login");
        }




    }
}
