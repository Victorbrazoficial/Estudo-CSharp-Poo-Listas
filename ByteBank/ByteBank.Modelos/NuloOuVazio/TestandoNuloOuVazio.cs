using System;
namespace ByteBank.Modelos.NuloOuVazio
{
    public class TestandoNuloOuVazio
    {
        public string URL { get; }

        private readonly string _argumentos;

        public TestandoNuloOuVazio(string url)
        {
            bool testeString = String.IsNullOrEmpty(url); // Metodo Statico da Class String testa IsNullorEmpty
            
            if (testeString)
                throw new ArgumentException("O Argumento Exception não pode ser nulo ou vazio", nameof(url));

            int indiceInterrogacao = url.IndexOf('?');
            _argumentos = url.Substring(indiceInterrogacao + 1);

            URL = url;
        }

        public string GetArgumento()
        {
            return _argumentos;
        }
    }
}