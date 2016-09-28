namespace DALService
{
    using Models;

    public class CommandEnvelope
    {
        public readonly ICommand command;
        public readonly string serializedCommand;

        public CommandEnvelope() { }

        public CommandEnvelope(ICommand command, string serializedCommand)
        {
            this.command = command;
            this.serializedCommand = serializedCommand;
        }
    }
}
