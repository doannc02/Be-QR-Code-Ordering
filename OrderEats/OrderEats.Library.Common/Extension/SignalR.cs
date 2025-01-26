using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderEats.Library.Common.Extension
{
    public static class SignalR
    {
        public static void AddSignalRServices(this IServiceCollection services)
        {
            services.AddSignalRServices();
        }   
    }
}
