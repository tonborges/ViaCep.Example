using Flunt.Notifications;
using System.Linq;
using ViaCep.Example.Core.Common;

namespace ViaCep.Example.Core.Services
{
    public class BaseService<T> : Notifiable<Notification> where T : class
    {
        protected ServiceResult<T> HandleResult(T data)
        {
            return new ServiceResult<T>
            {
                Data = data,
                Notifications = (this.Notifications?.Any() ?? false) ? this.Notifications : null,
                Status = IsValid ? ServiceResult.StatusResult.Ok : ServiceResult.StatusResult.Error
            };
        }
    }
}