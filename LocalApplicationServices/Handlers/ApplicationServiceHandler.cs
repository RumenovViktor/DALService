namespace LocalApplicationServices
{
    using LocalApplicationServices.Handlers.Contracts;
    using Models;

    public class ApplicationServiceHandler<T> : IApplicationServiceHandler<T>
    {
        public T Handle(T applicationService, ICommand command)
        {
            var model = ((dynamic)applicationService).Execute(command);
            return model;
        }
    }
}
