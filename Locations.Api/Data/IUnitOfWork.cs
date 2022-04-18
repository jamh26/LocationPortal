using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Locations.Api.Data
{
    public interface IUnitOfWork
    {
        IUsersRepository Users { get; }

        Task CompleteAsync();
    }
}
