﻿using System;
using System.Collections.Generic;

namespace TraSuaApp.Models;

public partial class Mon
{
    public int MaMon { get; set; }

    public string TenMon { get; set; } = null!;

    public int MaDm { get; set; }

    public decimal GiaBan { get; set; }

    public bool DangBan { get; set; }

    public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; } = new List<ChiTietHoaDon>();

    public virtual DanhMucMon MaDmNavigation { get; set; } = null!;
}
