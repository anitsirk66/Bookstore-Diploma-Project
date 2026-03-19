using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreProjectCore.Models.Cart
{
	public class CartItemViewModel
	{
		public Guid BookId { get; set; }
		public string Title { get; set; } = null!;
		public string CoverImageUrl { get; set; } = null!;
		public decimal UnitPrice { get; set; }
		public int Quantity { get; set; }

		public decimal TotalPrice => UnitPrice * Quantity;
	}
}
