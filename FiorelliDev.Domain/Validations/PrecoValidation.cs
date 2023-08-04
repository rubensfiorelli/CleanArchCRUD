using FiorelliDev.Domain.Notifications;

namespace Royal.Domain.Validations
{
    public partial class ContractValidations<T>
    {
        public ContractValidations<T> PrecoIsOk(decimal preco, string message, string propertyName)
        {
            if (preco <= 0)
            {
                AddNotification(new Notification(message, propertyName));
            }

            return this;
        }
    }
}
