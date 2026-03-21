using System.ComponentModel.DataAnnotations;

namespace DevJourney.AuthService.Domain.Entities
{
    public class User
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        //Implementar métodos de validação, autenticação, etc., conforme necessário
    }
}
