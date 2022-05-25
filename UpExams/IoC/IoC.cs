using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;

namespace UpExams
{
    /// <summary>
    /// The IoC container for our application
    /// </summary>
    public static class IoC
    {
        /// <summary>
        /// Gets a service from the IoC, of the specified type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Get<T>()
        {
            return Kernel.Get<T>();
        }
        /// <summary>
        /// The Kernel for our IoC container
        /// </summary>
        public static IKernel Kernel { get; private set; } = new StandardKernel();
        /// <summary>
        /// Sets up the IoC container, binds all the information required and is ready for use
        /// Must be called as soon as you app starts up
        /// </summary>
        public static void Setup()
        {
            // Bind all requierd view models
            BindViewModels();

        }
        /// <summary>
        /// Binds all singletons view models
        /// </summary>
        private static void BindViewModels()
        {
            // Bind to a single instance of Application view model
            Kernel.Bind<ApplicationViewModel>().ToConstant(new ApplicationViewModel());
        }
    }
}
