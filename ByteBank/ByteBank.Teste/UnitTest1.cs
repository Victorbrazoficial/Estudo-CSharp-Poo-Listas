using System.Reflection;
using Xunit;
using ByteBank.Modelos;
using ByteBank.SistemaAgencia;


namespace ByteBank.Teste
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            ContaCorrente conta = new ContaCorrente(123,456);

            var result = conta.Agencia;

             Assert.Equal(result, 123);

        }

        public void AdicionaItemNaLista()
        {
            ContaCorrente conta = new ContaCorrente(123,456);
            ContaCorrente conta2 = new ContaCorrente(44,456);

            Lista<ContaCorrente> lista = new Lista<ContaCorrente>();
            lista.Adicionar(conta2);
            var result = lista[0].Agencia;

            Assert.Equal(result, 44);
        }
    }

}