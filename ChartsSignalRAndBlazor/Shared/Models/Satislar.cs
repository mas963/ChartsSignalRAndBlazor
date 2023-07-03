using System;
using System.Collections.Generic;

namespace ChartsSignalRAndBlazor.Shared.Models;

public partial class Satislar
{
    public int Id { get; set; }

    public int? PersonelId { get; set; }

    public int? Fiyat { get; set; }
}
