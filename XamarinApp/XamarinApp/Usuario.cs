using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinApp
{
    public class Usuario
    {
        public string cedula { set; get; }
        public string correo { set; get; }
        public string contrasenna { set; get; }

        public Usuario() { }

        public Usuario(string pCedula, string pCorreo, string pContrasenna) 
        {
            this.cedula = pCedula;
            this.correo = pCorreo;
            this.contrasenna = pContrasenna;
        }
    }
}
