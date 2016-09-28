using Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Web.Http.Controllers;
using System.Web.Http.ModelBinding;

namespace DALService
{
    public class CommandModelBinder : ModelBinderAttribute, IModelBinder
    {
        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            try
            {
                var modelTypeName = actionContext.RequestContext.RouteData.Values["id"].ToString();
                var modelType = GetSpecificType(modelTypeName);

                if (actionContext.Request.Content.Headers.ContentType.MediaType == "application/json")
                {
                    var commandJson = actionContext.Request.Content.ReadAsStringAsync().Result;
                    var commandObj = JObject.Parse(commandJson)["command"].ToString();
                    
                    var command = (ICommand)JsonConvert.DeserializeObject(commandObj, modelType);
                    
                    bindingContext.Model = new CommandEnvelope(command, commandJson);

                    return true;
                }

                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        private Type GetSpecificType(string name)
        {
            var type = typeof(ICommand);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                                .SelectMany(s => s.GetTypes())
                                .Where(p => type.IsAssignableFrom(p));

            return types.FirstOrDefault(x => x.Name == name);
        }
    }
}