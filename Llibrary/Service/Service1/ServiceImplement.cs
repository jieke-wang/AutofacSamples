using System;

namespace Llibrary.Service.Service1
{
    public class ServiceImplement : IService
    {
        public void ShowService()
        {
            Console.WriteLine($"Service1");
        }

        public int Plus(int x, int y)
        {
            int z = x + y;
            return z;
        }
    }
}
