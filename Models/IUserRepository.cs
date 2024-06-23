using System.Collections.Generic;
using System.Net;

namespace WPF_LoginForm.Models
{
    /// <summary>
    /// Esta interfaz tiene el objetivo de declarar los métodos del repositorio de usuario
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Este método sirve para autenticar al usuario, como parámetros se pone usuario y contraseña. Dado que en la vista y modelo de vista la contraseña es tipo SecureString, entonces se usa la clase NetworkCredential ya que admite en el constructor una cadena tipo SecureString, y es posible obtener la contraseña en texto plano
        /// </summary>
        /// <param name="credential"></param>
        /// <returns></returns>
        bool AuthenticateUser(NetworkCredential credential);
        void Add(UserModel userModel);
        void Edit(UserModel userModel);
        void Remove(int id);
        UserModel GetById(int id);
        UserModel GetByUsername(string username);
        IEnumerable<UserModel> GetAll();
    }
}
