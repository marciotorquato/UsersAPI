namespace UsersApi.Domain.Entities
{
    public class UsuarioPerfil
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid UsuarioId { get; set; }
        public string? NomeCompleto { get; set; }
        public DateTimeOffset? DataNascimento { get; set; }
        public string? Pais { get; set; }
        public string? AvatarUrl { get; set; }


        public Usuario Usuario { get; set; } = null!;
    }
}
