namespace ByteBank.Modelos
{
    public class ParceiroComercial : IAutenticavel
    {
        public string Senha { get; set; }

        private AutenticacaoHelper _autenticadorHelper = new AutenticacaoHelper();

        public bool Autenticar(string senha)
        {
            return _autenticadorHelper.CompararSenhas(Senha, senha);
        }
    }
}