using System;
using System.Collections.Generic;

namespace Repo.Models;

public partial class Blog
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Content { get; set; }

    public string? Image { get; set; }

    public DateOnly? CreateDate { get; set; }

    public int BlogCategoryId { get; set; }

    public virtual BlogCategory BlogCategory { get; set; } = null!;
}
