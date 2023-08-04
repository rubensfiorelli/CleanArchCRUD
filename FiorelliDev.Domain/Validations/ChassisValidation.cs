using FiorelliDev.Domain.Notifications;

namespace Royal.Domain.Validations
{
    public partial class ContractValidations<T>
    {
        public ContractValidations<T> ImgUrlIsOk(string imagem, string message, string propertyName)
        {
            if (string.IsNullOrWhiteSpace(imagem))

                AddNotification(new Notification(message, propertyName));

            return this;
        }
    }
}
