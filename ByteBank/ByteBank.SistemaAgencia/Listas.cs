using System;
namespace ByteBank.SistemaAgencia
{
    public class Lista<T>
    {
         private T[] _item;

        private int _proximoPosicao;

        private T[] _novoTamanhoArray;
        
        public int Tamanho 
        {
            get 
            {
                return _proximoPosicao;
            }
         }

        public Lista(int capadicadeInicial = 5)
        {
            _item = new T[capadicadeInicial];
        }

        public void AdicionarVarios(params T[] itens)
        {
            foreach (T item in itens)
            {
                Adicionar(item);
            }
        }

        public void Adicionar(T item)
        {
            VerificarTamanhoArray();
            Console.WriteLine("Adicionando item na posição " + _proximoPosicao);

            _item[_proximoPosicao] = item;
            _proximoPosicao++;
        }

        public void Remover(T item)
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

            for (int i = indiceItem; i < _proximoPosicao - 1; i++)
                _item[i] = _item[i +1];

            _proximoPosicao--;
            
            Console.WriteLine("Removendo item no Indice " + (indiceItem));
        }

        public void VerificarTamanhoArray()
        {
            if (_proximoPosicao >= _item.Length)
            {
                Console.WriteLine("Criando novo Array");
                _novoTamanhoArray = new T[_item.Length * 2];

                for (int i = 0; i < _item.Length; i++)
                {
                    _novoTamanhoArray[i] = _item[i];
                }
                    _item = _novoTamanhoArray;
            }
        }       

        public T GetIndiceItem(int indice)
        {
            if (indice < 0 || indice >= Tamanho)
                throw new ArgumentOutOfRangeException(nameof(indice));

            return _item[indice];
        }

        public T this[int indice]
        {
            get
            {
                return GetIndiceItem(indice);
            }
        }
    }
}