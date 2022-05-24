using System.Linq;
using System.Text.RegularExpressions;
using System;
using ByteBank.Modelos;
using ByteBank.Modelos.DataTempo;
using ByteBank.Modelos.NuloOuVazio;
using System.Collections.Generic;
using ByteBank.SistemaAgencia.Extensoes;
using ByteBank.Modelos.Funcionarios;
using ByteBank.SistemaAgencia.Comparador;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {       
            //TestandoODateTime_1();
            //TestandoSubstring_1();
            //TestandoSubstring_2();
            //TestandoNuloOuVazioDaSubstring();
            //TestandoExpressaoRegular();
            //TestaArryInt();
            //TestaArreyContaCorrente();

            //TestaListaContaCorrente();
            //TestaListaDeObjetos();
            //TestaLista();

            //TestaExtensaoInt();

            // TestaSorts();

            //TestarSortComparador();

            TestaOrdeBy();

            //TestaWhereAntesDeOrderBy();
 
        }

        public static void TestaWhereAntesDeOrderBy()
        {
            var conta1 = new ContaCorrente(70,2);
            var conta3 = new ContaCorrente(50,1);
            var conta4 = new ContaCorrente(40,9);
            var conta2 = new ContaCorrente(20,3);
            ContaCorrente conta6 = null;
            ContaCorrente conta7 = null;
            var conta5 = new ContaCorrente(30,4);

            var lista = new List<ContaCorrente>();
            lista.AddVariosGenerico(conta3,conta2,conta4,conta6,conta7,conta5,conta1);

            var contasOrdenada = lista
                            .Where(conta => conta != null)
                            .OrderBy(conta => conta.Numero);

            foreach (var conta in contasOrdenada)
            {
                Console.WriteLine($"Agencia: {conta.Agencia} Numero: {conta.Numero}" );     
            }
        }

        public static void TestaOrdeBy()
        {
            var conta1 = new ContaCorrente(70,2);
            var conta3 = new ContaCorrente(50,1);
            var conta4 = new ContaCorrente(40,9);
            var conta2 = new ContaCorrente(20,3);
            ContaCorrente conta6 = null;
            ContaCorrente conta7 = null;
            var conta5 = new ContaCorrente(30,4);

            var lista = new List<ContaCorrente>();
            lista.AddVariosGenerico(conta3,conta2,conta4,conta6,conta7,conta5,conta1);

            // orderBy não altera a lista original ele retornar uma nova lista ordenada.
            IOrderedEnumerable<ContaCorrente> contasOrdenadas = lista.OrderBy(conta => 
            {
                if (conta == null)
                    return int.MaxValue;

                return conta.Agencia;
            });

            foreach (var conta in contasOrdenadas)
            {
                if (conta != null)
                {
                    Console.WriteLine($"Agencia: {conta.Agencia} Numero: {conta.Numero}" );
                }
                else 
                {
                    Console.WriteLine("Conta null");
                }
            }  
        }

        public static void TestarSortComparador()
        {
            var conta0 = new ContaCorrente(10,6);
            var conta1 = new ContaCorrente(5,2);
            var conta3 = new ContaCorrente(1,1);
            var conta4 = new ContaCorrente(13,9);
            var conta2 = new ContaCorrente(2,3);
            var conta5 = new ContaCorrente(3,4);
            
            var comparador = new ComparadorContaCorrente();
            var lista = new List<ContaCorrente>();

            lista.AddVariosGenerico(conta3,conta2,conta4,conta5,conta0,conta1);
            lista.Sort(comparador);
            
             foreach (var conta in lista)
             {
                 Console.WriteLine($"Agencia: {conta.Agencia} Numero: {conta.Numero}" );
             }
        }
        public static void TestaSorts()
        {
             var listaNomes = new List<string>();

             listaNomes.AddVariosGenerico("Braz", "Babi");
             listaNomes.Add("Sanzzio");
             listaNomes.Sort();

             for(int i = 0; i < listaNomes.Count; i++) 
             {
                 listaNomes[i].Escreva();
             }
        }

        public static void TestaExtensaoInt()
        {
            List<int> idade = new List<int>();
            idade.Add(1);
            idade.Add(2);
            
            AddVariosExtencao.AddVarios(idade, 3, 4);

            idade.AddVarios(5,6);

            for(int i = 0; i < idade.Count; i++) 
            {
                idade[i].Escreva();
            }

        }
        public static void TestaLista()
        {
            Lista<ContaCorrente> lista = new Lista<ContaCorrente>();
            ContaCorrente contaCorrente1 = new ContaCorrente(123,111);
            ContaCorrente contaCorrente2 = new ContaCorrente(123,222);

            lista.AdicionarVarios(contaCorrente1,contaCorrente2);
            lista.Remover(contaCorrente2);

            for (int i = 0; i < lista.Tamanho; i++)
            {
                Console.WriteLine(lista[i].Numero);
            }
        }

        public static void TestaListaDeObjetos()
        {
            
            ListaDeObjetos Idade = new ListaDeObjetos();
            Idade.AdicionarVarios(10,9,8,7,6,5,4,3,2,1);
            Idade.Adicionar(0);

            for (int i = 0; i < Idade.Tamanho; i++)
            {
                Console.WriteLine(Idade[i]);
            }
        }

        public static void TestaListaContaCorrente()
        {
            ListaContaCorrente lista = new ListaContaCorrente();
            ContaCorrente contaCorrente1 = new ContaCorrente(123,111);
            ContaCorrente contaCorrente2 = new ContaCorrente(123,222);
            ContaCorrente contaCorrente3 = new ContaCorrente(123,333);
            ContaCorrente contaCorrente4 = new ContaCorrente(123,444);
            ContaCorrente contaCorrente5 = new ContaCorrente(123,555);
            ContaCorrente contaCorrente6 = new ContaCorrente(123,666);
            ContaCorrente contaCorrente7 = new ContaCorrente(123,777);
            ContaCorrente contaCorrente8 = new ContaCorrente(123,888);
            ContaCorrente contaCorrente9 = new ContaCorrente(123,999);
            ContaCorrente contaCorrente10 = new ContaCorrente(123,1010);
            
            lista.AdicionarVarios
            (
                contaCorrente1, contaCorrente2, contaCorrente3,
                contaCorrente4, contaCorrente5, contaCorrente6, 
                contaCorrente7, contaCorrente8, contaCorrente9, contaCorrente10
            );
            
            lista.GetLista();

            lista.Remover(contaCorrente2);
            lista.GetLista();

            lista.Remover(contaCorrente9);
            lista.GetLista();

            lista.Adicionar(contaCorrente1);
            lista.GetLista();

            Console.Write($"Testando GetIndiceItem() {lista.GetIndiceItem(3).Numero} \n");
            Console.Write($"Testando indice formato lista[] {lista[0].Numero} \n");

            for (int i = 0; i < lista.Tamanho; i++)
            {
                ContaCorrente itemAtual = lista[i];
                Console.WriteLine($"Agencia: {itemAtual.Numero}");
            }
        }

        static void TestaArreyContaCorrente()
        {
             ContaCorrente[] contas = {new ContaCorrente(123,456), new ContaCorrente(123,789), new ContaCorrente(123,658)};
            for (int i = 0; i < contas.Length; i++)
            {
                Console.WriteLine("Conta: " + contas[i].Numero);
            }
        }

        static void TestaArryInt()
        {
             int[] arrey = {1,2,3,4};

            for (int i = 0; i < arrey.Length; i++)
            {
                Console.WriteLine(arrey[i]);
            }
        }

        static void TestandoODateTime_1()
        {
            TestandoDateTime dateTime = new TestandoDateTime();
            dateTime.Print();
            dateTime.PrintTimeNow();
            dateTime.DiasFaltantes();
        }

        static void TestandoSubstring_1()
        {
            string url = "texto?Alou";
            Console.WriteLine("String inicial: " + url);

            int indexUrl = url.IndexOf('?');

            string substringUrl = url.Substring(indexUrl + 1);
            Console.WriteLine("Substring = " + substringUrl);
            Console.WriteLine("Strings permanecem imutaveis: " +  url);
        }

        static void TestandoNuloOuVazioDaSubstring()
        {
            TestandoNuloOuVazio textoQualquer = new TestandoNuloOuVazio("asdasdsadsad?ulala");
            Console.WriteLine(textoQualquer.GetArgumento());
            TestandoNuloOuVazio nulo = new TestandoNuloOuVazio(null);
            TestandoNuloOuVazio vazio = new TestandoNuloOuVazio("");
        }

        static void TestandoSubstring_2()
        {
            string palavra = "moedaOrgigem=real&moedaDestino=dolar";
            string argumento = "moedaDestino";
            int indice = palavra.IndexOf(argumento);
            string substringPalavra = palavra.Substring(indice);
            int quantidadeDeLetrasNoArgumento = argumento.Length;
            int encontrandoSomaDoIndice = substringPalavra.Length + quantidadeDeLetrasNoArgumento + 1;
            string encontrado = palavra.Substring(encontrandoSomaDoIndice);


            Console.WriteLine("Palavra = " + palavra);
            Console.WriteLine("Argumento = " + argumento);
            Console.WriteLine("IndexOf da palavra com paremetro argumento = " + indice);
            Console.WriteLine("Substring da Palavra passando o indice = " + substringPalavra);
            Console.WriteLine("Quantidade de letras no argumento = " + quantidadeDeLetrasNoArgumento);
            Console.WriteLine("Soma da quantidade de letras do SubstringPalavra + quantidadeDeLetrasNoArgumento = " + encontrandoSomaDoIndice);
            Console.WriteLine("Resultado esperado = " + encontrado);
        }

        static void TestandoExpressaoRegular()
        {
            string padrao8NumerosComHifen = "Esse é o numero 8765-9949";
            string padraoSemHifen = "Numero atualizado 87659949";
            string padrao9NumerosSemHifen = "Numero novo 987659949";
            string padrao9NumerosComHifen = "numero novo 98765-9949 ";

            string padrao = "[0-9][0-9][0-9][0-9][-][0-9][0-9][0-9][0-9]";
            Console.WriteLine(Regex.Match(padrao8NumerosComHifen,padrao));

            string padrao2 = "[0-9]{4}[-][0-9]{4}";
            Console.WriteLine(Regex.Match(padrao8NumerosComHifen,padrao2));

            string padrao3 = "[0-9]{4,5}[-]{0,1}[0-9]{4}";
            Console.WriteLine(Regex.Match(padrao9NumerosComHifen,padrao3));            

            string padrao4 = "[0-9]{4,5}-?[0-9]{4}";
            Console.WriteLine(Regex.Match(padraoSemHifen,padrao4));            
            Console.WriteLine(Regex.Match(padrao9NumerosSemHifen,padrao4));
        }
    }
}
