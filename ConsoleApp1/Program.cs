using System;
using System.Reflection;

/*反射，reflection
 * 大意就是在main程序里面实例化一个对象，利用这个对象创造一个虚拟的对象
 * 这个虚拟的对象拥有实例化对象的方法和属性，那么就可以调用虚拟化对象的方法和属性
 * 这个就是反射
 * 
 * 以下的例子还是女孩和tank。
 */
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            ITank ik = new Tank();
            //==================================
            //以下就是反射code
            //得到动态的type
            var v = ik.GetType();
            Object o = Activator.CreateInstance(v);
            //用reflection 的这个方法得到动态type（虚拟化对象） 的方法
            MethodInfo fireMI = v.GetMethod("Fire");
            MethodInfo runMI = v.GetMethod("Run");
            //调用invoko
            fireMI.Invoke(o, null);
            runMI.Invoke(o, null);
        }
    }

    class Driver
    {
        private IVehicle _vehicle;

        public Driver(IVehicle vehicle)
        {
            _vehicle = vehicle;
        }

        public void Drive()
        {
            _vehicle.Run();

        }
    }
    interface IVehicle
    {
        void Run();
    }

    class Car : IVehicle
    {
        public void Run()
        {
            Console.WriteLine("Car is running");
        }
    }

    class Truck : IVehicle
    {
        public void Run()
        {
            Console.WriteLine("Truck is running");
        }
    }
    //类和类只能有一个接口就是子类和父类。接口可以有多个接口。一个类也可以有多个接口
    interface ITank : IVehicle, IWeapon
    {

    }

    interface IWeapon
    {
        void Fire();
    }

    class Tank : ITank
    {
        public void Fire()
        {
            Console.WriteLine("Fire!!!!!!");
        }

        public void Run()
        {
            Console.WriteLine("Tank is running");
        }
    }
}
