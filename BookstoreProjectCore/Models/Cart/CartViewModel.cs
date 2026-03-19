using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreProjectCore.Models.Cart
{
	public class CartViewModel
	{
		public List<CartItemViewModel> Items { get; set; } = new();

		public decimal TotalPrice => Items.Sum(x => x.TotalPrice);
	}
}
