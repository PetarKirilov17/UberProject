using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uber.Core.OpenRouteService.Models
{
    public class MatrixInputModel
    {

        public MatrixInputModel()
        {
            locations = new List<List<double>>();
            sources = new List<int>();
        }

        public List<List<double>> locations { get; set; }
        public List<int> sources { get; set; }
    }
}
