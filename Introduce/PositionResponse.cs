using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Introduce
{
    public class PositionResponse
    {
        public Rect Rect { get; set; }

        public PathGeometry PathGeometry { get; set; }

        public double[] Xy { get; set; }
    }
}
