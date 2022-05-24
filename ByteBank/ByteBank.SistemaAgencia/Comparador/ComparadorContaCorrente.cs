using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using ByteBank.Modelos;

namespace ByteBank.SistemaAgencia.Comparador
{
    public class ComparadorContaCorrente : IComparer<ContaCorrente>
    {
        public int Compare(ContaCorrente x, ContaCorrente y)
        {
            if (x == y)
                return 0;

            if (x.Agencia < y.Agencia )
                return -1;

            if (x.Agencia == y.Agencia)
                return 0;

            return 1;
  
            //  Nossas comparações de numeros interos é equivalente ao que ja exite no tipo INT
            //return x.Agencia.CompareTo(y.Agencia);
        }
    }
}