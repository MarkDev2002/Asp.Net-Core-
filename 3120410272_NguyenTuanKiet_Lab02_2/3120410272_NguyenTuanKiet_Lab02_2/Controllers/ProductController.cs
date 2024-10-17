using Microsoft.AspNetCore.Mvc;
using _3120410272_NguyenTuanKiet_Lab02_2.Models;

namespace Lab2.Controllers
{
    public class ProductController : Controller
    {
        static List<Product> products = new List<Product>();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShowAll()
        {
            ViewData["Heading"] = "All Products";
            if (products.Count == 0)
            {
                products.Add(new Product { ID = 101, Name = "IPad 2018", Price = 499 });
                products.Add(new Product { ID = 102, Name = "IPhone X", Price = 999 });
                products.Add(new Product { ID = 103, Name = "SS Note 9", Price = 1099 });
            }
            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("Id", "Name", "Price")] Product product)
        {
            //thêm vào danh sách
            products.Add(product);
            //gọi hiển thị danh sách
            return RedirectToAction("ShowAll");
        }

        public IActionResult Edit(int id)
        {
            Product p = products.SingleOrDefault(q => q.ID == id);
            if (p != null) //tìm thấy
            {
                return View(p);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Edit(int id, [Bind("Id", "Name", "Price")] Product product)
        {
            //Sửa vào danh sách
            Product p = products.SingleOrDefault(q => q.ID == id);
            if (p != null) //tìm thấy
            {
                p.Name = product.Name;
                p.Price = product.Price;
            }
            //gọi hiển thị danh sách
            return RedirectToAction("ShowAll");
        }

        public IActionResult Delete(int id)
        {
            //tìm Product cần xóa (dùng LINQ)
            Product p = products.SingleOrDefault(q => q.ID == id);
            if (p != null) //tìm thấy
            {
                products.Remove(p);
            }
            //gọi hiển thị danh sách
            return RedirectToAction("ShowAll");
        }
    }
}
