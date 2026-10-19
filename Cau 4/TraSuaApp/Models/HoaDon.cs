﻿using System;
using System.Collections.Generic;

namespace TraSuaApp.Models;

public partial class HoaDon
{
    public int MaHd { get; set; }

    public DateTime GioLap { get; set; }

    public string HinhThuc { get; set; } = null!;

    public decimal TongTien { get; set; }

    public bool DaThanhToan { get; set; }

    public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; } = new List<ChiTietHoaDon>();
}
