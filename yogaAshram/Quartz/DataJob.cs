using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using yogaAshram.Models;
using yogaAshram.Services;
using yogaAshram.Workers;

namespace yogaAshram.Quartz
{
    public class DataJob: IJob
    {
        private readonly IServiceScopeFactory serviceScopeFactory;
        public DataJob(IServiceScopeFactory serviceScopeFactory)
        {
            this.serviceScopeFactory = serviceScopeFactory;
        }
        public async Task Execute(IJobExecutionContext context)
        {
           using (var scope = serviceScopeFactory.CreateScope())
           {
               var emailsender = scope.ServiceProvider.GetService<IBot>();
               emailsender.StartBot();
           }
        }
        
    }
}