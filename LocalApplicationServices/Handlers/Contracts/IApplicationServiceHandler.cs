namespace LocalApplicationServices.Handlers.Contracts
{
    using Models;

    public interface IApplicationServiceHandler<T>
    {
        T Handle(T applicationService, ICommand command);
    }
}
