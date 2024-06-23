namespace WPF_LoginForm.Models
{
    public class UserModel
    {
        // En este caso no tiene sentido usar tipo de datos SecureString para la contraseña ya que en algún momento será necesario convertirla en texto plano para realizar validaciones y/o guardarla en DB. Sin embargo, se debe cifrar la contraseña inmediatamente después de ser creada.
        public string Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}