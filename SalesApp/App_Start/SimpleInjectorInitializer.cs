[assembly: WebActivator.PostApplicationStartMethod(typeof(SalesApp.App_Start.SimpleInjectorInitializer), "Initialize")]

namespace SalesApp.App_Start
{
    using System.Reflection;
    using System.Web.Mvc;
    using Application.Services.Customer.Classes;
    using Application.Services.Customer.Interfaces;
    using Application.Services.Employee.Classes;
    using Application.Services.Employee.Interfaces;
    using Application.Services.Invoice.Classes;
    using Application.Services.Invoice.Interfaces;
    using Application.Services.Products.Classes;
    using Application.Services.Products.Interfaces;
    using SimpleInjector;
    using SimpleInjector.Integration.Web;
    using SimpleInjector.Integration.Web.Mvc;
    
    public static class SimpleInjectorInitializer
    {
        /// <summary>Initialize the container and register it as MVC3 Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            
            InitializeContainer(container);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            
            container.Verify();
            
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
     
        private static void InitializeContainer(Container container)
        {
            //#error Register your services here (remove this line).

            // For instance:
            // container.Register<IUserRepository, SqlUserRepository>(Lifestyle.Scoped);
            container.Register<ICustomerAppServices, CustomerAppServices>(Lifestyle.Scoped);
            container.Register<IEmployeeAppServices, EmployeeAppServices>(Lifestyle.Scoped);
            container.Register<IProductAppServices , ProductAppServices >(Lifestyle.Scoped);
            container.Register<IInvoiceHeaderAppServices, InvoiceHeaderAppServices>(Lifestyle.Scoped);
            container.Register<IInvoiceItemAppServices, InvoiceItemAppServices>(Lifestyle.Scoped);
        }
    }
}