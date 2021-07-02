using System;

namespace Llibrary.Service.Service3
{
    public class ServiceImplement : IService
    {
        public Service2.IService Service2 { protected get; set; }

        public void ShowService()
        {
            Service2.ShowService();
            Console.WriteLine($"Service3\n");
        }

        public int Plus(int x, int y)
        {
            int z = Service2.Plus(x, y);
            return z;
        }
    }
}
