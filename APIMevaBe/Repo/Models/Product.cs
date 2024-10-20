﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PRN221_MeVaBe_Repo.Models;

public partial class Product
{
    public int Id { get; set; }

    public string? ProductName { get; set; }

    public string? CoverImage { get; set; }

    public double? Price { get; set; }

    public bool? Status { get; set; }

    public string? Description { get; set; }

    public int ProductCategoryId { get; set; }

    public virtual Feedback IdNavigation { get; set; } = null!;
    [JsonIgnore]
    public virtual ProductCategory ProductCategory { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<CartItem> TblCartItems { get; set; } = new List<CartItem>();
    [JsonIgnore]
    public virtual ICollection<OrderItem> TblOrderItems { get; set; } = new List<OrderItem>();
    [JsonIgnore]
    public virtual ICollection<ProductSubImage> TblProductSubImages { get; set; } = new List<ProductSubImage>();
}
