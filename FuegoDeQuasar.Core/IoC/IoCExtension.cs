using FuegoDeQuasar.Core.Helpers;
using FuegoDeQuasar.Core.Operations;
using FuegoDeQuasar.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace FuegoDeQuasar.Core.IoC
{
    public static class IoCExtension
    {
        public static void ConfigureCore(this IServiceCollection services)
        {
            services.AddSingleton<IMathOperation, MathOperation>();
            services.AddSingleton<IInitializatorHelper, InitializatorHelper>();
            services.AddScoped<ITrilaterationOperation, TrilaterationOperation>();
            services.AddScoped<IMessageOperation, MessageOperation>();
        }
    }
}
