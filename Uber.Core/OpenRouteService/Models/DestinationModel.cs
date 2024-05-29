using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uber.Core.OpenRouteService.Models
{
    public class DestinationModel
    {
        public List<double>? location { get; set; }
        public double snapped_distance { get; set; }
    }
}
