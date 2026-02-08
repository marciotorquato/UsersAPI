namespace UsersApi.Domain.Entities
{
    public class Contato
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid UsuarioId { get; set; }
        public string? Celular { get; set; }
        public string? Email { get; set; }

        public Usuario Usuario { get; set; } = null!;
    }
}
