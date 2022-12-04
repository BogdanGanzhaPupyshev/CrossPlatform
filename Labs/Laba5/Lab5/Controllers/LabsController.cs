using Lab5.Models;
using Microsoft.AspNetCore.Mvc;
using ThreeTasksLibrary;

namespace Lab5.Controllers
{
    public class LabsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Lab1()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Lab1(Lab1Model lab1Model)
        {
            var inputPath = lab1Model.InputFile;
            var outputPath = lab1Model.OutputFile;

            lab1Model.Result = new Laba1().ExecuteFirstLab(inputPath, outputPath);

            return View(lab1Model);
        }

        public IActionResult Lab2()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Lab2(Lab2Model lab2Model)
        {
            var inputPath = lab2Model.InputFile;
            var outputPath = lab2Model.OutputFile;

            lab2Model.Result = new Laba2().ExecuteSecondLab(inputPath, outputPath);

            return View(lab2Model);
        }

        public IActionResult Lab3()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Lab3(Lab3Model lab3Model)
        {
            var inputPath = lab3Model.InputFile;
            var outputPath = lab3Model.OutputFile;

            lab3Model.Result = new Laba3().ExecuteThirdLab(inputPath, outputPath);

            return View(lab3Model);
        }
    }
}
