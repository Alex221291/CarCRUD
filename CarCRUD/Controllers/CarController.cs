using CarCRUD.Models;
using CarCRUD.Service;
using Microsoft.AspNetCore.Mvc;

namespace CarCRUD.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _carService.GetCars());
        }
        [HttpGet]
        public async Task<IActionResult> Details(int carId)
        {
            return View(await _carService.GetById(carId));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Cars carId)
        {
            await _carService.Remove(carId.Id);
            return RedirectToAction("Index", "Car");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Cars());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Cars car)
        {
            if (car.Name == string.Empty || car.Model == string.Empty || car.Type == string.Empty || car.Color == string.Empty)
            {
                ModelState.AddModelError("", "Данные не верны!");
                return View(car);
            }
            await _carService.Create(car);
            return RedirectToAction("Index", "Car");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int carId)
        {
            return View(await _carService.GetById(carId));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Cars car)
        {
            if (car.Name == string.Empty || car.Model == string.Empty || car.Type == string.Empty || car.Color == string.Empty)
            {
                ModelState.AddModelError("", "Данные не верны!");
                return View(car);
            }
            await _carService.Edit(car);
            return RedirectToAction("Index", "Car");
        }
    }
}
