namespace Areas
{
    // Общий интерфейс расчета фигур
    public interface IFigure
    {


        /// <summary>
        /// Возвращает площадь фигуры
        /// </summary>
        /// <returns></returns>
        public float GetArea();
        
        public float GetPerimeter();

        public void SetPoints(Tuple<float, float>[] points);
    }


    public class AbstractFigure : IFigure
    {
        Tuple<float, float>[] _points = null;

        public void SetPoints(Tuple<float, float>[] points)
        {
            _points = points;
        }

        /// <summary>
        /// Площадь фигуры
        /// </summary>
        /// <returns> Площадь фигуры</returns>
        public float GetArea()
        {
            float S = 0;
            //универсальтная формула -1/2 * Sum i ( Xi * Yi+1 - Yi*Xi+1 )
            for (int i = 0; i < _points.Length - 1; i++)
            {
                S = S + _points[i].Item1 * _points[i + 1].Item2 - _points[i].Item2 * _points[i + 1].Item1;
            }

            S = -1 / 2 * S;
            return (float) Math.Round(S,3);
        }

        /// <summary>
        /// Периметр фигуры
        /// </summary>
        /// <returns>Возвращает периметер фигуры</returns>
        public float GetPerimeter() 
        {
            float P = 0;
            //универсальтная формула Sum i (sqrt (Xi -Xi+1)^2 -  (Yi -Yi+1)^2 )
            for (int i = 0; i < _points.Length ; i++)
            {
                P = P + (float)Math.Round(Math.Sqrt(Math.Pow((_points[i].Item1 - _points[i + 1].Item1), 2) + Math.Pow((_points[i].Item2 - _points[i + 1].Item2), 2)),3);
            }
            
            return (float) Math.Round( P,3);
        }


    }

    /// <summary>
    /// Простой треугольник
    /// </summary>
    public class Simple_Triangle : IFigure
    {
        public float a {set; get;} = 0;
        public float b {set; get;} = 0;
        public float c { set; get; } = 0;
        /// <summary>
        /// Первая точка
        /// </summary>
        public float x { set; get; } = 0;
        public float y { set; get; } = 0;

        public void SetPoints(Tuple<float, float>[] points)
        {
            if (points == null || points.Length == 0) return;

            x = points[0].Item1;
            y = points[0].Item2;
        }

        /// <summary>
        /// Площадь фигуры
        /// </summary>
        /// <returns> Площадь фигуры</returns>
        public float GetArea()
        {
            float P = GetPerimeter() / 2;
            float S = (float)Math.Round(Math.Sqrt( P*(P-a)*(P-b)*(P-c)),3);
            
            return S;
        }

        /// <summary>
        /// Периметр  треугольник
        /// </summary>
        /// <returns>Возвращает периметер фигуры</returns>
        public float GetPerimeter()
        {
            float P = 0;
            P = (float )Math.Round( Math.Round( a + b + c,3), 3);
            return P ;
        }


        public bool is_Angle90()
        {
            //просто в квадратном треугольнике c^2  = a^2 + b^2 => c^2-(a^2 + b^2)~0
            return (Math.Round(Math.Abs(c * c - (a * a + b * b)), 3) < 0.001);


        }



    }

    /// <summary>
    /// Простой треугольник
    /// </summary>
    public class Simple_Circle : IFigure
    {
        public float r { set; get; } = 0;
        public float x { set; get; } = 0;
        public float y { set; get; } = 0;

        public void SetPoints(Tuple<float, float>[] points)
        {
            if (points == null || points.Length == 0) return;

            x = points[0].Item1;
            y = points[0].Item2;
        }

        /// <summary>
        /// Площадь круга
        /// </summary>
        /// <returns> Площадь фигуры</returns>
        public float GetArea()
        {
            
            float S = (float)Math.Round(Math.PI * r*r,3);

            return S;
        }

        /// <summary>
        /// Периметр  круга
        /// </summary>
        /// <returns>Возвращает периметер фигуры</returns>
        public float GetPerimeter()
        {
            float P =  (float) Math.Round( (2* Math.PI * r),3);
            return P;
        }

        
    }


}