using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_TallerdeProgramacion_Aguilar_Juarez.modelo
{
    internal class Usuario
    {


        private int id;
        private string username;
        private string password;
        private string rol;
        private bool activo;

        public Usuario(string username, string password, bool isHashed = false)
        {
            this.Username = username;
            // Si el password ya está hasheado, lo asignamos directamente
            this.Password = isHashed ? password : BCrypt.Net.BCrypt.HashPassword(password);
        }

        public Usuario(string username, string password, string rol, bool activo, bool isHashed = false)
        {
            this.Username = username;
            // Si el password ya está hasheado, lo asignamos directamente
            this.Password = isHashed ? password : BCrypt.Net.BCrypt.HashPassword(password);
            this.Rol = rol;
            this.Activo = activo;
        }

        public int Id { get => id; set => id = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string Rol { get => rol; set => rol = value; }
        public bool Activo { get => activo; set => activo = value; }
    }
}
