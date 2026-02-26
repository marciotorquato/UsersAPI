using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersAPI.Domain.Events;

namespace UsersAPI.Domain.Interfaces.Events;

public interface IEventPublisher
{
    Task PublishUserCreatedAsync(UserCreatedEvent userEvent);
}