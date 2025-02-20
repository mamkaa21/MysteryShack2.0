using System;
using System.Collections.Generic;

namespace MysteryShack;

public partial class Good
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public double? Price { get; set; }

    public int? Amount { get; set; }

    public int? IdCategory { get; set; }

    public virtual Category? IdCategoryNavigation { get; set; }
}
