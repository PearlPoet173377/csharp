using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice.Practice_01
{
    public interface IFigure3D : IFigure
    {
        double Volume { get; }
        double SurfaceArea { get; }
    }
}
