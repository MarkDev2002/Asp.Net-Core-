using Microsoft.AspNetCore.Mvc;

namespace _3120410272_NguyenTuanKiet_Lab02_1.Controllers
{
    public class CalculatorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Calculate(double a = 0, double b = 0, char op = '+')
        {
            switch (op)
            {
                case '+':
                    ViewBag.KetQua = a + b;
                    break;
                case '-':
                    ViewBag.KetQua = a - b;
                    break;
                case '*':
                    ViewBag.KetQua = a * b;
                    break;
                case '/':
                    ViewBag.KetQua = a / b;
                    break;
            }
            return View("Index");
        }
    }
}
    