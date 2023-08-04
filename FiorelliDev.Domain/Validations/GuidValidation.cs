using FiorelliDev.Domain.Notifications;

namespace Royal.Domain.Validations
{
    public partial class ContractValidations<T>
    {
        public ContractValidations<T> GuidIsOk(object guid, string message, string propertyName)
        {
            if (guid is not Guid)
                AddNotification(new Notification(message, propertyName));

            return this;
        }
    }
}
