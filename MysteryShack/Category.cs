﻿using System;
using System.Collections.Generic;

namespace MysteryShack;

public partial class Category
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public virtual ICollection<Good> Goods { get; set; } = new List<Good>();
    //public override string ToString()
    //{
    //    return $" Название {Title}";
    //}
}
