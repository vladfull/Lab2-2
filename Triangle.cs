using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Triangles
{
    public class Triangle
    {
        public int[,] points = new int[3, 2];
        public double side1;
        public double side2;
        public double side3;
        public void Equality(Triangle t)
        {
            if (side1 == t.side1 & side2 == t.side2 & side3 == t.side3) Console.WriteLine("true");
            else Console.WriteLine("false");
        }
        public double Perimetr()
        {
            double P = side1 + side2 + side3;
            Console.WriteLine($"Периметр:{P}");
            return P;
        }
        public double Area()
        {
            double p = (side1 + side2 + side3)/2;
            double area = Math.Sqrt(p*(p-side1)*(p-side2)*(p-side3));
            Console.WriteLine($"Площа:{area}");
            return area;
        }
        public void Heights()
        {
            double area = Area();
            double H1 = (2*area)/side1;
            double H2 = (2 * area) / side2;
            double H3 = (2 * area) / side3;
            Console.WriteLine($"Висоти: 1) {H1}, 2) {H2}, 3) {H3}");
        }
        public void Medians()
        {
            double[,] middles = new double[3,2];
            for(int i = 0; i < middles.GetLength(0); i++)
            {
               if(i + 1 < points.GetLength(0))
               {
                    middles[i, 0] = (points[i, 0] + points[i + 1, 1]) / 2;
                    middles[i, 1] = (points[i, 0] + points[i, 1]) / 2;
               }
               else
               {
                    middles[i, 0] = (points[i, 0] + points[0, 1]) / 2;
                    middles[i, 1] = (points[i, 0] + points[i, 1]) / 2;
               }
            }
            double median1 = Math.Sqrt(Math.Pow(middles[0, 0] - points[2, 0], 2) + Math.Pow(middles[0,1] - points[2, 1], 2));
            double median2 = Math.Sqrt(Math.Pow(middles[1, 0] - points[0, 0], 2) + Math.Pow(middles[1, 1] - points[0, 1], 2));
            double median3 = Math.Sqrt(Math.Pow(middles[2, 0] - points[2, 0], 2) + Math.Pow(middles[2, 1] - points[0, 1], 2));
            Console.WriteLine($"Медіани: 1) {median1}, 2) {median2}, 3) {median3}");
        }
        public void Bisectors()
        {
            double P = Perimetr();
            double b1 = Math.Sqrt(side2 * side3 * P * (side2 + side3 - side1)) / (side2 + side3);
            double b2 = Math.Sqrt(side1 * side3 * P * (side1 + side3 - side1)) / (side1 + side3);
            double b3 = Math.Sqrt(side2 * side1 * P * (side2 + side1 - side3)) / (side2 + side1);
            Console.WriteLine($"Бісектриси: 1) {b1}, 2) {b2}, 3) {b3}");
        }
        public void Radiuses()
        {
            double area = Area();
            double p = (side1 + side2 + side3) / 2;
            double r = Math.Sqrt(((p-side1)*(p-side2)*(p-side3))/p);
            double R = (side1*side2*side3)/4*area;
            Console.WriteLine($"Радіус вписаного кола: {r}. Радіус описаного кола: {R}");
        }
        public void Type()
        {
            string type;
            int k1 = (points[0, 0] - points[1, 0]) * (points[1, 0] - points[2, 0]) + (points[0, 1] - points[1, 1]) * (points[1, 1] - points[2, 1]);
            int k2 = (points[1, 0] - points[2, 0]) * (points[2, 0] - points[0, 0]) + (points[1, 1] - points[2, 1]) * (points[2, 1] - points[0, 1]);
            int k3 = (points[2, 0] - points[0, 0]) * (points[0, 0] - points[1, 0]) + (points[2, 1] - points[0, 1]) * (points[0, 1] - points[1, 1]);
            double cos1 = (Math.Pow(side1, 2) + Math.Pow(side2, 2) - Math.Pow(side3, 2)) / (2 * side1 * side2); //cos(α)=(a²+b²−c²)÷(2×a×b)
            double cos2 = (Math.Pow(side2, 2) + Math.Pow(side3, 2) - Math.Pow(side1, 2)) / (2 * side3 * side2); //cos(β)=(b²+c²−a²)÷(2×b×c)
            double cos3 = (Math.Pow(side1, 2) + Math.Pow(side3, 2) - Math.Pow(side2, 2)) / (2 * side1 * side3); //cos(γ)=(a²+c²−b²)÷(2×a×c)
            if (side1 == side2 | side2 == side3 | side1 == side3) type = "Рівнобедрений";
            if (side1 == side2 & side2 == side3) type = "Рівноcторонній";
            if (k1 == 0 | k2 == 0 | k3 == 0) type = "Прямокутний";
            else if (Math.Acos(cos1) > Math.Acos(0) | Math.Acos(cos2) > Math.Acos(0) | Math.Acos(cos3) > Math.Acos(0)) type = "Тупокутний";
            else type = "Гострокутний";
            Console.WriteLine(type);
        }
        public void Povorot(int kut)
        {
            double kutRad = kut * Math.PI / 180;
            double xSide1Pov = (points[1, 0] - points[0, 0])*Math.Cos(kutRad) - (points[1, 1] - points[0, 1])*Math.Sin(kutRad);
            double ySide1Pov = (points[1, 0] - points[0, 0]) * Math.Sin(kutRad) + (points[1, 1] - points[0, 1]) * Math.Cos(kutRad);
            double xSide2Pov = (points[2, 0] - points[1, 0]) * Math.Cos(kutRad) - (points[2, 1] - points[1, 1]) * Math.Sin(kutRad);
            double ySide2Pov = (points[2, 0] - points[1, 0]) * Math.Sin(kutRad) + (points[2, 1] - points[1, 1]) * Math.Cos(kutRad);
            Console.WriteLine("Поворот відносно вершини А");
            Console.WriteLine($"Координати точки В після повороту: x = {xSide1Pov}, y = {ySide1Pov}");
            Console.WriteLine($"Координати точки С після повороту: x = {xSide2Pov}, y = {ySide2Pov}");

        }
        public void PovorotCentr(int kut)
        {
            double kutRad = kut * Math.PI / 180;
            double[,] middles = new double[3, 2];
            for (int i = 0; i < middles.GetLength(0); i++)
            {
                if (i + 1 < points.GetLength(0))
                {
                    middles[i, 0] = (points[i, 0] + points[i + 1, 1]) / 2;
                    middles[i, 1] = (points[i, 0] + points[i, 1]) / 2;
                }
                else
                {
                    middles[i, 0] = (points[i, 0] + points[0, 1]) / 2;
                    middles[i, 1] = (points[i, 0] + points[i, 1]) / 2;
                }
            }
            double xC = (middles[0,0] + middles[1,0] + middles[2,0])/3;//x = (a.x + b.x + c.x) / 3
            double yC = (middles[0, 1] + middles[1, 1] + middles[2, 1]) / 3;//y = (a.y + b.y + c.y) / 3
            double xSide1Pov = (xC - points[0, 0]) * Math.Cos(kutRad) - (yC - points[0, 1]) * Math.Sin(kutRad);
            double ySide1Pov = (xC - points[0, 0]) * Math.Sin(kutRad) + (yC - points[0, 1]) * Math.Cos(kutRad);
            double xSide2Pov = (xC - points[1, 0]) * Math.Cos(kutRad) - (yC - points[1, 1]) * Math.Sin(kutRad);
            double ySide2Pov = (xC - points[1, 0]) * Math.Sin(kutRad) + (yC - points[1, 1]) * Math.Cos(kutRad);
            double xSide3Pov = (xC - points[2, 0]) * Math.Cos(kutRad) - (yC - points[2, 1]) * Math.Sin(kutRad);
            double ySide3Pov = (xC - points[2, 0]) * Math.Sin(kutRad) + (yC - points[2, 1]) * Math.Cos(kutRad);
            Console.WriteLine("Поворот відносно центру оп. кола");
            Console.WriteLine($"Координати точки А після повороту: x = {xSide1Pov}, y = {ySide1Pov}");
            Console.WriteLine($"Координати точки B після повороту: x = {xSide2Pov}, y = {ySide2Pov}");
            Console.WriteLine($"Координати точки C після повороту: x = {xSide3Pov}, y = {ySide3Pov}");
        }
        public string Serialize(string file)
        {
            string json = JsonConvert.SerializeObject(this);
            File.WriteAllText(file, json);
            Console.WriteLine(json);
            return json;
        }
        public Triangle Deserialize(string file) 
        {
            string json = File.ReadAllText(file);
            Triangle t = JsonConvert.DeserializeObject<Triangle>(json);
            Console.WriteLine(t.ToString);
            return t;
        }
        public Triangle(int[,] points)
        {
            this.points = points;
            side1 = Math.Sqrt(Math.Pow(points[0, 0] - points[1, 0], 2) + Math.Pow(points[0, 1] - points[1, 1], 2));
            side2 = Math.Sqrt(Math.Pow(points[1, 0] - points[2, 0], 2) + Math.Pow(points[1, 1] - points[2, 1], 2));
            side3 = Math.Sqrt(Math.Pow(points[2, 0] - points[0, 0], 2) + Math.Pow(points[2, 1] - points[0, 1], 2));
        }
    }
}
