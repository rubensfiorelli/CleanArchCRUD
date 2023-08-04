using FiorelliDev.Domain.Notifications;

namespace Royal.Domain.Validations
{
    public partial class ContractValidations<T>
    {
        public ContractValidations<T> EstoqueIsOk(int estoque, string message, string propertyName)
        {
            if (estoque <= 0)
            {
                AddNotification(new Notification(message, propertyName));
            }

            return this;
        }
    }
}
