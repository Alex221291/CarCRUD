using CarCRUD.Models;
using CarCRUD.Service;
using Microsoft.AspNetCore.Mvc;

namespace CarCRUD.Controllers
{
    public class MotoController : Controller
    {
        private readonly IMotoService _motoService;

        public MotoController(IMotoService motoService)
        {
            _motoService = motoService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _motoService.GetMotos());
        }
        [HttpGet]
        public async Task<IActionResult> Details(int motoId)
        {
            return View(await _motoService.GetById(motoId));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Motos motoId)
        {
            await _motoService.Remove(motoId.Id);
            return RedirectToAction("Index", "Moto");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Motos());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Motos moto)
        {
            await _motoService.Create(moto);
            return RedirectToAction("Index", "Moto");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int motoId)
        {
            return View(await _motoService.GetById(motoId));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Motos moto)
        {
            await _motoService.Edit(moto);
            return RedirectToAction("Index", "Moto");
        }
    }
}
