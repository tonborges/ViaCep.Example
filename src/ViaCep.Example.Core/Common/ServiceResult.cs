using Flunt.Notifications;
using System.Collections.Generic;

namespace ViaCep.Example.Core.Common
{
    public class ServiceResult
    {
        public IEnumerable<Notification> Notifications { get; set; }
        public StatusResult Status { get; set; }

        public enum StatusResult
        {
            Ok,
            Error,
            Warning
        }
    }

    public class ServiceResult<T> : ServiceResult
    {
        public T Data { get; set; }
    }
}