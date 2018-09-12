using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Messages;


namespace DeleteARecord
{
    public class deleteArecord : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            ITracingService tracingService = (ITracingService)serviceProvider.GetService(typeof(ITracingService));
            tracingService.Trace("Tracing service invoked");

            IPluginExecutionContext context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
            tracingService.Trace("Context Obtained Invoked");


            if(context.InputParameters.Contains("Target") & context.InputParameters["Target"] is Entity)
            {

                Entity account = (Entity)context.InputParameters["Target"];

                if (account.LogicalName != "account")
                    return;

            try
            {

            IOrganizationServiceFactory organizationServiceFactory = (IOrganizationServiceFactory)serviceProvider.GetService
                        (typeof(IOrganizationServiceFactory));

            IOrganizationService service = organizationServiceFactory.CreateOrganizationService(context.UserId);

            tracingService.Trace("Org Service Invoked");

                   


                }
                catch
                {


                }
            }

        




        }
    }
}
