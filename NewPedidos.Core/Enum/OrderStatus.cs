using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPedidos.Core.Enum
{
    public enum OrderStatus
    {
     
        Started = 0,
        Cancelled = 1,
        Fronzen = 2,
        Finished = 3,
        PaymentPending = 4
    }
}
