using Cadastro.Models.Enuns;

namespace Cadastro.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public long Cpf { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public ClasseEnum Preferencia { get; set; }
    }
}