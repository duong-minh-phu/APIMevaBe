using System;
using System.Collections.Generic;

namespace Repo.Models;

public partial class BlogCategory
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Blog> TblBlogs { get; set; } = new List<Blog>();
}
