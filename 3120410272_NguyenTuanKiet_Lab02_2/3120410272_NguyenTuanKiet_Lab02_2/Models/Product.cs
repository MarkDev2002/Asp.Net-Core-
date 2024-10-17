using System.ComponentModel.DataAnnotations;

namespace _3120410272_NguyenTuanKiet_Lab02_2.Models
{
    public class Product
    {
        [Key]
        public int ID { get; set; }

        [MaxLength(30, ErrorMessage = "Không dài quá 30 ký tự")]
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
