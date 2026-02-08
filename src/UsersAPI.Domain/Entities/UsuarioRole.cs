namespace UsersApi.Domain.Entities
{
    public class UsuarioRole
    {
        public UsuarioRole() { }

        public UsuarioRole(int roleId)
        {
            Id = Guid.NewGuid();
            RoleId = roleId;
        }

        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid UsuarioId { get; set; }
        public int RoleId { get; set; }

        public Usuario Usuario { get; set; } = null!;
        public Role Role { get; set; } = null!;
    }
}
