using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace practice.Practice-02
{
    class Paral : Figure3d
    {
        
        public double Width { get;set; };
        public double Height { get; set; }
        public double Depth { get; set; }

        public Paral(double width, double height, double depth)
        {
            Width = width; Height = height; Depth = depth;
        }

        public double SideSurface()
        {
            return Height * Width * 2 + Height * Depth * 2 + Depth * Width * 2;
        }
 
        public double Volume()
        {
            return height * width * depth;

        }

        public string Describe() => $"Parallelepiped:\nVolume: {Volume}\nSurfaceArea: {SurfaceArea}";
}
