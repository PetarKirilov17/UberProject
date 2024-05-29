using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uber.Core.OpenRouteService.Models
{
    public class MatrixResultModel
    {
        public List<List<double>>? durations { get; set; }
        public List<DestinationModel>? destinations { get; set; }

        public List<SourceModel>? sources { get; set; }


    }
}
