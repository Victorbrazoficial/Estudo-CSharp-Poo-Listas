using System;
using ByteBank.Modelos;

namespace ByteBank.SistemaAgencia
{
    public class ListaContaCorrente
    {
        private ContaCorrente[] _item;

        private int _proximoPosicao;

        private ContaCorrente[] _novoTamanhoArray;
        
        public int Tamanho 
        {
            get 
            {
                return _proximoPosicao;
            }
         }

        public ListaContaCorrente(int capadicadeInicial = 5)
        {
            _item = new ContaCorrente[capadicadeInicial];
        }

        public void AdicionarVarios(params ContaCorrente[] itens)
        {
            foreach (ContaCorrente conta in itens)
            {
                Adicionar(conta);
            }
        }

        public void Adicionar(ContaCorrente item)
        {
            VerificarTamanhoArray();
            Console.WriteLine("Adicionando item na posição " + _proximoPosicao);

            _item[_proximoPosicao] = item;
            _proximoPosicao++;
        }

        public void Remover(ContaCorrente item)
        {
            int indiceItem = 0;

            for (int i = 0; i < _proximoPosicao; i++)
            {
                if (_item[i].Equals(item))
                {
                    indiceItem = i;
                    break;
                }      
            }

             //[intem 1] [item 3] [null]
             //                       ^
             //                          `_proximaPosicao


            for (int i = indiceItem; i < _proximoPosicao - 1; i++)
                _item[indiceItem] = _item[indiceItem +1];

            _proximoPosicao--;
            _item[_proximoPosicao] = null;
            
            Console.WriteLine("Removendo item no Indice " + (indiceItem));
        }

        public void VerificarTamanhoArray()
        {
            if (_proximoPosicao >= _item.Length)
            {
                Console.WriteLine("Criando novo Array");
                _novoTamanhoArray = new ContaCorrente[_item.Length * 2];

                for (int i = 0; i < _item.Length; i++)
                {
                    _novoTamanhoArray[i] = _item[i];
                }
                    _item = _novoTamanhoArray;
            }
        }       
        public ContaCorrente GetIndiceItem(int indice)
        {
            if (indice < 0 || indice >= Tamanho)
                throw new ArgumentOutOfRangeException(nameof(indice));

            return _item[indice];
        }

        public ContaCorrente this[int indice]
        {
            get
            {
                return GetIndiceItem(indice);
            }
        }

        public ContaCorrente[] GetLista()
        {
            Console.WriteLine("Lista: ");

            for (int i = 0; i < _proximoPosicao; i++)
            { 
                Console.WriteLine("Indice " + i + " Agencia: " + _item[i].Agencia + " Numero: " + _item[i].Numero);        
            }

            return  _item;
        }
    }
}