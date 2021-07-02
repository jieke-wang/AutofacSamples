using System;
using Autofac.Extras.DynamicProxy;
using Llibrary.Interceptors;

namespace Llibrary.Service.Service2
{
    [Intercept(typeof(ConsoleLogInterceptor))]
    public class ServiceImplement : IService
    {
        private readonly Service1.IService _service1;

        public ServiceImplement(Service1.IService service1)
        {
            _service1 = service1;
        }

        public virtual void ShowService()
        {
            _service1.ShowService();
            Console.WriteLine($"Service2");
        }

        public virtual int Plus(int x, int y)
        {
            int z = _service1.Plus(x, y);
            return z;
        }
    }
}
