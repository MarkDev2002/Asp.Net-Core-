﻿using Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("OrderItems")]
	public class OrderItem : EntityBase<int>
    {
		public int OrderId { get; set; }
		public int BookId { get; set; }
		public int Quantity { get; set; }
		public decimal Price { get; set; }
		public Order Order { get; set; }
		public Book Book { get; set; }
	}
}
