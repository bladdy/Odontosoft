using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odontosoft.Shared.Interfaces
{
    public interface IBaseEntity
    {
        Guid Id { get; set; }
    }
}