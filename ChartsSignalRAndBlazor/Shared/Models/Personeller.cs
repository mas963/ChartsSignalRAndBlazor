using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ChartsSignalRAndBlazor.Shared.Models;

public partial class Personeller
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int? Id { get; set; }

    public string? Adi { get; set; }

    public string? Soyadi { get; set; }
}
