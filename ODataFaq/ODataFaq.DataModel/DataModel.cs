﻿using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace ODataFaq.DataModel
{
    public class Customer
    {
		public Customer()
		{
			this.CustomerId = Guid.NewGuid();
			this.Orders = new OrderCollection();
		}

		[Key]
		public Guid CustomerId { get; set; }

		[MaxLength(200)]
		[Required(AllowEmptyStrings = false)]
		public string CompanyName { get; set; }

		[MaxLength(2)]
		[Required(AllowEmptyStrings = false)]
		public string CountryIsoCode { get; set; }

		public OrderCollection Orders { get; private set; }
	}

	public class Product
	{
		public Product()
		{
			this.ProductId = Guid.NewGuid();
			this.OrderDetails = new OrderDetailCollection();
		}

		[Key]
		public Guid ProductId { get; set; }

		[MaxLength(200)]
		[Required(AllowEmptyStrings = false)]
		public string Description { get; set; }

		[MaxLength(10)]
		[Required(AllowEmptyStrings = false)]
		public string CategoryCode { get; set; }

		[Required]
		public bool IsAvailable { get; set; }

		[Required]
		public decimal PricePerUom { get; set; }

		public OrderDetailCollection OrderDetails { get; set; }
	}

    public class OrderHeader
	{
		public OrderHeader()
		{
			this.OrderId = Guid.NewGuid();
		}

		[Key]
		public Guid OrderId { get; set; }

		[Required]
		public Customer Customer { get; set; }

		[Required]
		public DateTimeOffset OrderDate { get; set; }

		public OrderDetailCollection OrderDetails { get; set; }
	}

	public class OrderCollection : Collection<OrderHeader> { }

	public class OrderDetail
	{
		public OrderDetail()
		{
			this.OrderDetailId = Guid.NewGuid();
		}

		[Key]
		public Guid OrderDetailId { get; set; }

		[Required]
		public Product Product { get; set; }

		[Required]
		public int Amount { get; set; }

		[Required]
		public OrderHeader Order { get; set; }
	}

	public class OrderDetailCollection : Collection<OrderDetail> { }
}
