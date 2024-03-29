﻿using _30julio.Data;
using _30julio.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _30julio.Controllers
{
    public class SociosController : Controller
    {
        private readonly ApplicationDbContext _context;
        public SociosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SociosController
        public ActionResult Index()
        {
            List<Socio> lissocios = new List<Socio>();
            lissocios = _context.Socios.ToList();
            return View(lissocios);
        }

        // GET: SociosController/Details/5
        public ActionResult Details(string id)
        {
            Socio socio = _context.Socios.Where(y => y.Cedula == id).FirstOrDefault();

            return View(socio);
        }

        // GET: SociosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SociosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Socio socio)
        {
            try
            {
                socio.Estado = 1;
                _context.Add(socio);
                _context.SaveChanges();
                return RedirectToAction("Index");
       
            }
            catch
            {
                return View(socio);
            }       
        }

        // GET: SociosController/Edit/5
        public ActionResult Edit(string id)
        {
            Socio socio = _context.Socios.Where(y => y.Cedula == id).FirstOrDefault();

            return View(socio);

        }

        // POST: SociosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, Socio socio)
        {
            if(id!=socio.Cedula)
            {
                return RedirectToAction("Index");
            }
            try
            {
                _context.Update(socio);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View(socio);
            }
        }

        
    }
}
