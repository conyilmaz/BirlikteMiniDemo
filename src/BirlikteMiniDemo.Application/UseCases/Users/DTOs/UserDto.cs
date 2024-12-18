namespace BirlikteMiniDemo.Application.UseCases.Users.DTOs
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = null!;
        public Guid? BasketId { get; set; }
    }
}
