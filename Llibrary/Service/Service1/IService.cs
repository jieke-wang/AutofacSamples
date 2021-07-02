using System;
using Llibrary.Interceptors;
using Autofac.Extras.DynamicProxy;

namespace Llibrary.Service.Service1
{
    [Intercept(typeof(ConsoleLogInterceptor))]
    public interface IService
    {
        int Plus(int x, int y);
        void ShowService();
    }
}
