namespace UsersApi.Domain.Entities
{
    public class Usuario
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nome { get; set; } = null!;
        public string Senha { get; set; } = null!; // ideal armazenar hash
        public bool Ativo { get; set; } = true;
        public DateTimeOffset DataCriacao { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset? DataAtualizacao { get; set; }

        // Navigation
        public UsuarioPerfil? Perfil { get; set; }
        public ICollection<Contato> Contatos { get; set; } = [];
        public ICollection<Endereco> Enderecos { get; set; } = [];
        public ICollection<UsuarioRole> UsuarioRoles { get; set; } = [];
    }
}
