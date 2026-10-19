﻿using System;
using System.Collections.Generic;

namespace TraSuaApp.Models;

public partial class DanhMucMon
{
    public int MaDm { get; set; }

    public string TenDm { get; set; } = null!;

    public virtual ICollection<Mon> Mons { get; set; } = new List<Mon>();
}
