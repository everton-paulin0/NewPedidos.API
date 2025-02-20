using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPedidos.Core.Enum
{
    public enum DocumentType
    {
        [Description("CPF")]
        Cpf,
        [Description("CNPJ")]
        CNPJ
    }
}
