using FiorelliDev.Domain.Notifications;

namespace Royal.Domain.Validations
{
    public partial class ContractValidations<T>
    {
        public ContractValidations<T> DescricaoIsOk(string descricao, short minLength, short maxLength, string message, string propertyName)
        {
            if (string.IsNullOrEmpty(descricao) || (descricao.Length < minLength) || (descricao.Length > maxLength))

                AddNotification(new Notification(message, propertyName));

            return this;
        }

    }
}
