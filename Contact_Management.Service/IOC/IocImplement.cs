using Contact_Management.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Contact_Management.Service.Ioc
{
    public static class IocImplement
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IContactRepository, ContactRepository>();

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IContactService, ContactService>();

            services.AddScoped<IJwtService, JwtService>();
        }
    }
}