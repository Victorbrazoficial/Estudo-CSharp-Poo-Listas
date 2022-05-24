using System.Collections.Generic;
using System;

namespace ByteBank.SistemaAgencia.Extensoes
{
    public static class ConsoleExtencao
    {
        public static void Escreva(this object obj)
        {
            Console.WriteLine(obj);
        }
    }

    public static class AddVariosExtencao
    {
        public static void AddVarios(this List<int> listaDeInteiros, params int[] itens)
        {
            foreach(int item in itens)
            {
                listaDeInteiros.Add(item);
            }
        }

        public static void AddVariosGenerico<T>(this List<T> lista, params T[] itens)
        {
            foreach (T item in itens)
            {
                lista.Add(item);
            }
        }
    }
}