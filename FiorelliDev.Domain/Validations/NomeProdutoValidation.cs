using FiorelliDev.Domain.Notifications;

namespace Royal.Domain.Validations
{
    public partial class ContractValidations<T>
    {
        public ContractValidations<T> NomeIsOk(string nome, short maxLength, short minLength, string message, string propertyName)
        {
            if (string.IsNullOrEmpty(nome) || (nome.Length < minLength) || (nome.Length > maxLength))

                AddNotification(new Notification(message, propertyName));

            return this;
        }
    }
}
