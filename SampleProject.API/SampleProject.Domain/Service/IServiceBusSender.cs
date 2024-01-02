using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.Domain.Service
{
    public interface IServiceBusSender<T>
    {
        Task SendQueryQueue(T message);
        Task SendQueryListQueue(List<T> message);
        Task SendCommandQueue(string message);
    }
}
