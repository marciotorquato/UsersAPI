namespace UsersApi.Domain.Entities
{
    public class Usuario
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nome { get; set; } = null!;
        public string Senha { get; set; } = null!;
        public bool Ativo { get; set; } = true;
        public DateTimeOffset DataCriacao { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset? DataAtualizacao { get; set; }


        public UsuarioPerfil? Perfil { get; set; }
        public ICollection<Contato> Contatos { get; set; } = [];
        public ICollection<Endereco> Enderecos { get; set; } = [];
        public ICollection<UsuarioRole> UsuarioRoles { get; set; } = [];

        public static Usuario Criar(string nome, string senha, bool ativo = true)
        {
            return new Usuario
            {
                Id = Guid.NewGuid(),
                Nome = nome,
                Senha = senha,
                Ativo = ativo,
                DataCriacao = DateTime.UtcNow
            };
        }

        public void AlterarSenha(string senha)
        {
            Senha = senha;
            DataAtualizacao = DateTime.UtcNow;
        }

        public void AlterarStatus(bool ativo)
        {
            Ativo = ativo;
            DataAtualizacao = DateTime.UtcNow;
        }
    }
}
