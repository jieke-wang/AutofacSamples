using System;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Llibrary.Interceptors;

namespace Llibrary
{
    public class LlibraryModule : Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<ConsoleLogInterceptor>(); // 注册拦截器

            containerBuilder
                .RegisterType<Service.Service1.ServiceImplement>() // 注册服务
                .As<Service.Service1.IService>() // 指定注册服务的接口
                .SingleInstance() // 生命周期为Singleton
                .EnableInterfaceInterceptors(); // 开启接口拦截,在接口上使用InterceptAttribute标记拦截器

            containerBuilder
                .RegisterType<Service.Service2.ServiceImplement>() // 注册服务
                .As<Service.Service2.IService>() // 指定注册服务的接口
                .InstancePerLifetimeScope() // 生命周期为Scope
                .EnableClassInterceptors(); // 开启类型拦截(注: 连接的方法必须使用virtual修饰,否则无法拦截),在类型上使用InterceptAttribute标记拦截器

            containerBuilder
                .RegisterType<Service.Service3.ServiceImplement>() // 注册服务
                .As<Service.Service3.IService>() // 指定注册服务的接口
                .InstancePerDependency() // 生命周期为Transient
                .PropertiesAutowired(); // 开启属性注入,注入属性的set访问器的访问范围必须为public
        }
    }
}
