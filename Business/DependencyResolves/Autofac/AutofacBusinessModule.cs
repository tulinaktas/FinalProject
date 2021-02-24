using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.CCS;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolves.Autofac
{
    //startupta yaptığımız islemleri yapmak icin Module claasını ekledik
     public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //IProductService istendiginde ProductManager ver
            //AddSingleton gibi
            builder.RegisterType<ProductManager>()
                .As<IProductService>().SingleInstance();
            
            builder.RegisterType<EFProductDal>()
                .As<IProductDal>().SingleInstance();

            builder.RegisterType<CategoryManager>()
               .As<ICategoryService>().SingleInstance();

            builder.RegisterType<EFCategoryDal>()
                .As<ICategoryDal>().SingleInstance();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();

        }
    }
}
