using Microsoft.VisualStudio.TestTools;
using Microsoft.VisualStudio.TestPlatform;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
using Areas;


namespace Check_Figures
{
    [TestClass]
    public class Check_Figures
    {
        [TestMethod]
        public void One()
        {
            float x = 10;
            float y = 20;
            float r = 5;

            Areas.Simple_Circle circle = new Areas.Simple_Circle();
            circle.x = x;
            circle.y = y;
            circle.r = r;

            // Объект создается
            Assert.AreNotEqual(circle, null);

            float res_wait_perimeter  = circle.GetPerimeter();
            // ожидаем 
            float res_wait_s =  circle.GetArea();

            //Проверка площади
            float check_s = (float) Math.Round(r * r * Math.PI, 3);

            //Проверка периметра
            float check_perimter = (float)Math.Round(2 * r * Math.PI, 3);

            Assert.AreEqual(res_wait_s, check_s);
            Assert.AreEqual(res_wait_perimeter,check_perimter);
        }

        [TestMethod]
        public void Check_circle_invlaid_params()
        {
            float x = 10;
            float y = 20;
            float r = 0;

            Areas.Simple_Circle circle = new Areas.Simple_Circle();
            circle.x = x;
            circle.y = y;
            circle.r = r;

            // Объект создается
            Assert.AreNotEqual(circle, null);

            float res_wait_perimeter = circle.GetPerimeter();
            // ожидаем 
            float res_wait_s = circle.GetArea();

            //Проверка площади
            float check_s = (float)Math.Round(r * r * Math.PI, 3);

            //Проверка периметра
            float check_perimter = (float)Math.Round(2 * r * Math.PI, 3);

            Assert.AreEqual(res_wait_s, check_s);
            Assert.AreEqual(res_wait_perimeter, check_perimter);
        }


        [TestMethod]
        public void Check_circle_by_dR()
        {
            float x = -2;
            float y = 20;
            float r = -5;

            Areas.Simple_Circle circle = new Areas.Simple_Circle();
            circle.x = x;
            circle.y = y;
            circle.r = r;

            // Объект создается
            Assert.AreNotEqual(circle, null);

            //Проверка площади
            float check_s = (float)Math.Round(r * r * Math.PI, 3);

            //Проверка периметра
            float check_perimter = (float)Math.Round(2 * r * Math.PI, 3);


            float res_wait_perimeter = circle.GetPerimeter();
            Assert.AreEqual(res_wait_perimeter - check_perimter,0);
        }

        [TestMethod]
        public void CheckTriangles()
        {
            float x = -2;
            float y = 20;
            float r = 15;

            float a = 5;
            float b = 13;
            float c = 23;


            Areas.Simple_Circle circle = new Areas.Simple_Circle();
            circle.x = x;
            circle.y = y;
            circle.r = r;

            Areas.Simple_Triangle triangle = new Areas.Simple_Triangle();
            triangle.x = x;
            triangle.y = y;
            triangle.a= a;
            triangle.b= b;  
            triangle.c= c;

            //Не один объект в коде
            Assert.AreNotEqual(circle, triangle);

            //Проверка площади
            float check_p = (float) (a+b+c)/2;

            //Проверка периметра
            float check_S = (float)Math.Round( Math.Sqrt( check_p*(check_p-a)* (check_p-b) * (check_p-c)  )  , 3);


            float res_wait_S = triangle.GetArea();
            Assert.AreEqual(res_wait_S, check_S);

            Assert.AreNotEqual(res_wait_S, 0);
            Assert.AreNotEqual(res_wait_S, null);
            Assert.AreNotEqual(triangle,null);
        }


        [TestMethod]
        public void CheckTrianglesOn90()
        {
            float x = -2;
            float y = 20;
          

            float a = 5;
            float b = 3;
            float c = (float )Math.Sqrt( a*a + b*b);


            Areas.Simple_Triangle triangle = new Areas.Simple_Triangle();
            triangle.x = x;
            triangle.y = y;
            triangle.a = a;
            triangle.b = b;
            triangle.c = c;

            
            //Проверка площади
            float check_S = (float) Math.Round((float)(a * b ) / 2, 3);

            float res_wait_S = triangle.GetArea();
            Assert.AreEqual(res_wait_S, check_S);

            Assert.AreEqual( Math.Round (c - 5.8309,3) ,0);
            //На косяк
            Assert.AreNotEqual(Math.Round(c, 3), 6);
            //На косяк
            Assert.AreNotEqual(Math.Round(c, 3), 0);


            Assert.AreNotEqual(res_wait_S, null);
            Assert.AreNotEqual(triangle, null);
        }




        [TestMethod]
        public void CheckTriangles_by_Invalid()
        {
            float x = -2;
            float y = 20;
            float r = 15;

            float a = -5;
            float b = 0;
            float c = 5 ;


            Areas.Simple_Triangle triangle = new Areas.Simple_Triangle();
            Assert.AreNotEqual(triangle, null);

            triangle.x = x;
            triangle.y = y;
            triangle.a = a;
            triangle.b = b;
            triangle.c = c;


            //Проверка площади
            float check_p = (float)(a + b + c) / 2;

            //Проверка периметра
            float check_S = (float)Math.Round(Math.Sqrt(check_p * (check_p - a) * (check_p - b) * (check_p - c)), 3);


            float res_wait_S = triangle.GetArea();
            Assert.AreEqual(Math.Abs(res_wait_S- check_S),0);
            Assert.AreNotEqual(res_wait_S, null);
            
        }

    }
}