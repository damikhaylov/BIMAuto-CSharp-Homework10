using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Угол задан с помощью целочисленных значений gradus - градусов, min - угловых минут,
            sec - угловых секунд.Реализовать класс, в котором указанные значения представлены в виде
            свойств. Для свойств предусмотреть проверку корректности данных. Класс должен содержать
            конструктор для установки начальных значений, а также метод ToRadians для перевода угла
            в радианы. Создать объект на основе разработанного класса. Осуществить использование
            объекта в программе.
            */

            Console.WriteLine("Использование класса Angle для получения свойств угла\n");

            Console.WriteLine("задайте угол целочисленными значениями градусов, минут и секунд:");

            try
            {
                Angle angle = new Angle();

                Console.Write("Введите значение градусов: ");
                angle.Deg = Convert.ToInt32(Console.ReadLine());                
                Console.Write("Введите значение минут: ");
                angle.Min = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введите значение секунд: ");
                angle.Sec = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("\nВведено значение: {0}", angle.ToString());
                Console.WriteLine("Значение угла в градусах с десятичной частью: {0}", angle.GetDecimalDegrees());
                Console.WriteLine("Значение угла в радианах: {0}", angle.ToRadians());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка! " + ex.Message);
            }
            Console.ReadKey();
        }
    }
    class Angle
    {
        int minutes;
        int seconds;

        public Angle(int degrees = 0, int min = 0, int sec = 0)
        {
            this.Deg = degrees;
            this.Min = min;
            this.Sec = sec;
        }

        public double GetDecimalDegrees()
        {
            if (this.Deg >= 0)
            {
                return (double)this.Deg + ((double)this.Min) / 60 + ((double)this.Sec) / 3600;
            }
            else
            {
                return (double)this.Deg - ((double)this.Min) / 60 - ((double)this.Sec) / 3600;
            }
            
        }

        public double ToRadians()
        {
            return this.GetDecimalDegrees() * Math.PI / 180;
        }

        public override string ToString()
        {
            return String.Format("{0}° {1}' {2}''", this.Deg, this.Min, this.Sec);
        }

        public int Deg { set; get; }
        
        public int Min
        {
            set
            {
                if (value >= 0 && value < 60)
                {
                    minutes = value;
                }
                else
                { 
                    throw new Exception("Задано недопустимое значение угловых минут.");
                }
            }
            get
            {
                return minutes;
            }
        }
        
        public int Sec
        {
            set
            {
                if (value >= 0 && value < 60)
                {
                    seconds = value;
                }
                else
                {
                    throw new Exception("Задано недопустимое значение угловых секунд.");
                }
            }
            get
            {
                return seconds;
            }
        }
    }
}
