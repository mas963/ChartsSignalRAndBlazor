using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartsSignalRAndBlazor.Shared.DTO;

public class ChartDto
{
    public string Label { get; set; }
    public List<double> Data { get; set; }
}
