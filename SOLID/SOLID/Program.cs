using System;

namespace SOLID
{
    class Program
    {
        static void Main(string[] args)
        {
            #region LISKOV subsitution
            //Apple apple = new Apple();
            //Fruit orange = new Orange();
            #endregion
        }


    }

    #region S.O.L.I.D
    #region Single responsibility
    class Type
    {
        public string GroupType { get; set; }
    }

    class Group
    {
        public string Name { get; set; }
        public Type GroupType { get; set; }
    }
    class Student
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public Group Group { get; set; }
    }
    #endregion
    #region Open/close
    interface IShape
    {
        double GetArea();
    }
    class Circle:IShape
    {
        public double Radius { get; set; }
        public double GetArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }
    }
    class Square : IShape
    {
        public double Length { get; set; }
        public double GetArea()
        {
            return Math.Pow(Length, 2);
        }
    }

    class Rectangle : IShape
    {
        public double Length { get; set; }
        public double Width { get; set; }

        public double GetArea()
        {
            return Width*Length;
        }
    }

    class Area
    {
        public double CountArea(IShape shape)
        {
            return shape.GetArea();

            //if(shape is Rectangle rectangle)
            //{
            //    return rectangle.GetArea();
            //}else if(shape is Square square)
            //{
            //    return square.GetArea();
            //}else if(shape is Circle circle)
            //{
            //    return circle.GetArea();
            //}
            //else
            //{
            //    return 0;
            //}
        }
    }
    #endregion
    #region LISKOV subsitution
    abstract class Fruit
    {
        public abstract void Tasty();
    }
    class Apple:Fruit
    {
        public override void Tasty()
        {
            Console.WriteLine("As Apple");
        }
    }

    class Orange: Fruit
    {
        public override void Tasty()
        {
            Console.WriteLine("As Orange");
        }
    }
    #endregion
    #region Interface Segregation
    //interface ICalc
    //{
    //    double Sum(double n1,double n2);
    //    double Difference(double n1, double n2);
    //    double Multiple(double n1, double n2);
    //    double Divide(double n1, double n2);
    //}

    class Calculate : ISum,IDifference,IDivide,IMultiple
    {
        public double Difference(double n1, double n2)
        {
            throw new NotImplementedException();
        }

        public double Divide(double n1, double n2)
        {
            throw new NotImplementedException();
        }

        public double Multiple(double n1, double n2)
        {
            throw new NotImplementedException();
        }

        public double Sum(double n1, double n2)
        {
            throw new NotImplementedException();
        }
    }

    interface ISum
    {
        double Sum(double n1, double n2);
    }

    interface IDifference
    {
        double Difference(double n1, double n2);
    }

    interface IMultiple
    {
        double Multiple(double n1, double n2);
    }

    interface IDivide
    {
        double Divide(double n1, double n2);
    }

    class Salary : ISum
    {
        public double Sum(double n1, double n2)
        {
            throw new NotImplementedException();
        }
    }
    #endregion
    #region Dependency injection
    interface IDatabase
    {
        void GetData(string data);
    }

    class Database : IDatabase
    {
        public void GetData(string data)
        {
            Console.WriteLine(data);
        }
    }

    class Service
    {
        public Product Product { get; set; }
        public Customer Customer { get; set; }

        public Service()
        {
            Database db = new Database();
            Product = new Product(db);
            Customer = new Customer(db);
        }
    }

    class Product
    {
        private readonly IDatabase _db;

        public Product(IDatabase db)
        {
            _db = db;
        }

        public void GetProductData()
        {
            _db.GetData("product data");
        }
    }

    class Customer
    {
        private readonly IDatabase _db;

        public Customer(IDatabase db)
        {
            _db =db;
        }

        public void GetCustomerData()
        {
            _db.GetData("customer data");
        }
    }
    #endregion
    #endregion
}
