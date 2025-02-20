using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPedidos.Core.Enum
{
    public enum OrderStatus
    {
        [Description("Iniciado")]
        Started,
        [Description("Cancelado")]
        Cancelled,
        [Description("Congelado")]
        Fronzen,
        [Description("Finalizaso")]
        Finished,
        [Description("Pagamento Pendente")]
        PaymentPending
    }
}
