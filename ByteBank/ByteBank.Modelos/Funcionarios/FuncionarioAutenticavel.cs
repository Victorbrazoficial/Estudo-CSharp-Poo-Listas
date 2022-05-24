using ByteBank;

namespace ByteBank.Modelos.Funcionarios
{
    public abstract class FuncionarioAutenticavel : Funcionario, IAutenticavel
    {
         public string Senha { get; set; }

         private AutenticacaoHelper _autenticadorHelper = new AutenticacaoHelper();

        public FuncionarioAutenticavel(double salario, string cpf)
            : base(salario, cpf)
        {
        }

        public bool Autenticar(string senha)
        {
            return _autenticadorHelper.CompararSenhas(Senha, senha);
        }
    }
}