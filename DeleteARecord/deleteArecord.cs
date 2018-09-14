using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Query;



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

            string AccountStatus = account["new_accountstatus"].ToString();
            tracingService.Trace("Account Status Updated to " + AccountStatus);

            //String AccountStatus =account.FormattedValues["new_accountstatus"].ToString();
            //string AS = account["new_accountstatus"].ToString();
            //int value = ((OptionSetValue)account["new_accountstatus"]).Value;
            //tracingService.Trace("Option set :"+AS);
            //tracingService.Trace("Option set value :{0}",value);
            //tracingService.Trace("before Exception");

            if (AccountStatus == "False")
            {

            QueryExpression query = new QueryExpression("contact");
            query.ColumnSet = new ColumnSet(new string[] { "contactid", "fullname" });
            query.Criteria.AddCondition(new ConditionExpression("parentcustomerid", ConditionOperator.Equal, account.Id));
            EntityCollection results = service.RetrieveMultiple(query);
                        tracingService.Trace("inside if block");
                        tracingService.Trace("Count :" + results.Entities.Count);
                        tracingService.Trace("Count :" + results.EntityName);
                        tracingService.Trace("Results :" + results.ToString());
                
            foreach(Entity con in results.Entities)
                        {
                            tracingService.Trace("Name" + con["fullname"]);
                        }

                 
            }                

            }
            catch (Exception e)
            {
                    tracingService.Trace("{0}", e.ToString());
                    throw;
            }
          }
       }
    }
}
