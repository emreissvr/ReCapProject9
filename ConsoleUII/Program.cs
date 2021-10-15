
using Business.Concrete;
using Core.Entities.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarTest();
            //CarAddTest();
            //BrandNameTest();

            //CustomerAdded();
            //UserAdded();
            //RentalCarDetails();
        }

        //private static void CustomerAdded()
        //{
        //    CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
        //    var result = customerManager.Add(new Customer { UserId = 1, CompanyName = "Walmart"});
        //    if (result.Success)
        //    {
        //        Console.WriteLine(result.Message);
        //    }
        //    else
        //    {
        //        Console.WriteLine(result.Message);
        //    }
        //}

        //private static void UserAdded()
        //{
        //    UserManager userManager = new UserManager(new EfUserDal());
        //    var result = userManager.Add(new User { UserId = 2, FirstName = "Ali", LastName = "Koç", Password = "1907", Email = "AliKoc@gmail.com"});
        //    if (result.Success)
        //    {
        //        Console.WriteLine(result.Message);
        //    }
        //    else
        //    {
        //        Console.WriteLine(result.Message);
        //    }

        //}

        //private static void RentalCarDetails()
        //{
        //    RentalManager rentalManager = new RentalManager(new EfRentalDal());

        //    foreach (var rental in rentalManager.GetRentalDetails().Data)
        //    {
        //        Console.WriteLine(rental.RentalId + "/" + rental.CarName + "/" + rental.CustomerName + "/" + rental.RentDate + "/" + rental.ReturnDate);
        //    }
        //}



        //public static void CarAddTest()
        //{
        //    Car car = new Car { CarId = 2, BrandId = 1002,ColorId = 2002,ModelYear = "2019",DailyPrice= 2000,Description="BMW M4"};

        //    CarManager carManager = new CarManager(new EfCarDal());
        //    carManager.Add(car);


        //}

        //private static void BrandNameTest()
        //{
        //    BrandManager brandmanager = new BrandManager(new EfBrandDal());


        //    var result = brandmanager.GetAll();
            
        //    if(result.Success == true)
        //    {
        //        foreach (var brand in result.Data)
        //        {
        //            Console.WriteLine(brand.BrandName);
        //        }
                 
        //    }
        //    else
        //    {
        //        Console.WriteLine(result.Message);
        //    }
               
            
            

        //}



        //private static void CarTest()
        //{
        //    CarManager carManager = new CarManager(new EfCarDal());

        //    //foreach (var car in carManager.GetAll())
        //    //{
        //    //    Console.WriteLine(car.CarId);
        //    //    Console.WriteLine(car.Description);
        //    //}

        //    foreach (var car in carManager.GetCarDetails().Data)
        //    {
        //        Console.WriteLine(car.Description + "/" + car.BrandName + "/" + car.ColorName + "/" + car.DailyPrice);
        //    }

        //}

        

    }
}