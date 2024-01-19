namespace shopecommerce.Domain.Commons.Commands
{
    public class CommandBase : ICommand
    {
        public Guid id { get; }
        public CommandBase()
        {
            this.id = Guid.NewGuid();
        }
        protected CommandBase(Guid id)
        {
            this.id = id;
        }
    }

    public abstract class CommandBase<TResponse> : ICommand<TResponse>
    {
        public Guid id { get; private set; }
        public string user_id { get; private set; }
        protected CommandBase()
        {
            this.id = Guid.NewGuid();
        }

        protected CommandBase(Guid id)
        {
            this.id = id;
        }

        public void SetUserId(string userId)
        {
            this.user_id = userId;
        }
        public void SetId(string id)
        {
            this.id = BaseGuidEx.GetGuid(id);
        }
    }
}
