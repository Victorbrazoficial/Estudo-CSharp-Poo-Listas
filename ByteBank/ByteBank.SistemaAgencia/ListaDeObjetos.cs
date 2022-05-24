using System;
namespace ByteBank.SistemaAgencia
{
    public class ListaDeObjetos
    {
        private Object[] _item;

        private int _proximoPosicao;

        private Object[] _novoTamanhoArray;
        
        public int Tamanho 
        {
            get 
            {
                return _proximoPosicao;
            }
         }

        public ListaDeObjetos(int capadicadeInicial = 5)
        {
            _item = new Object[capadicadeInicial];
        }

        public void AdicionarVarios(params Object[] itens)
        {
            foreach (Object item in itens)
            {
                Adicionar(item);
            }
        }

        public void Adicionar(Object item)
        {
            VerificarTamanhoArray();
            Console.WriteLine("Adicionando item na posição " + _proximoPosicao);

            _item[_proximoPosicao] = item;
            _proximoPosicao++;
        }

        public void Remover(Object item)
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
            _item[_proximoPosicao] = null;
            
            Console.WriteLine("Removendo item no Indice " + (indiceItem));
        }

        public void VerificarTamanhoArray()
        {
            if (_proximoPosicao >= _item.Length)
            {
                Console.WriteLine("Criando novo Array");
                _novoTamanhoArray = new Object[_item.Length * 2];

                for (int i = 0; i < _item.Length; i++)
                {
                    _novoTamanhoArray[i] = _item[i];
                }
                    _item = _novoTamanhoArray;
            }
        }       

        public Object GetIndiceItem(int indice)
        {
            if (indice < 0 || indice >= Tamanho)
                throw new ArgumentOutOfRangeException(nameof(indice));

            return _item[indice];
        }

        public Object this[int indice]
        {
            get
            {
                return GetIndiceItem(indice);
            }
        }
    }
}