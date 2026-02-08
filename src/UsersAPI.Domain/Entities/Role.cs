namespace UsersApi.Domain.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string RoleName { get; set; } = null!;
        public string? Description { get; set; }

        public ICollection<UsuarioRole> UsuarioRoles { get; set; } = [];
    }
}
