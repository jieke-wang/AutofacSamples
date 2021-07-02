using System;
using Castle.DynamicProxy;

namespace Llibrary.Interceptors
{
    public class ConsoleLogInterceptor : IInterceptor
    {
        private static void InterceptPrevious(IInvocation invocation)
        {
            Console.WriteLine($"TargetType: {invocation.TargetType}; Instance: {invocation.InvocationTarget?.GetHashCode()}; Method Name: {invocation.Method.Name}; Arguments: {string.Join(",", invocation.Arguments)}; ReturnValue: {invocation.ReturnValue}; 执行前");
        }

        public void Intercept(IInvocation invocation)
        {
            InterceptPrevious(invocation);

            try
            {
                invocation.Proceed();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex}");
            }

            InterceptAfter(invocation);
        }

        private static void InterceptAfter(IInvocation invocation)
        {
            // Console.WriteLine($"{invocation.Proxy}");
            
            Console.WriteLine($"TargetType: {invocation.TargetType}; Instance: {invocation.InvocationTarget?.GetHashCode()}; Method Name: {invocation.Method.Name}; Arguments: {string.Join(",", invocation.Arguments)}; ReturnValue: {invocation.ReturnValue}; 执行后");
        }
    }
}