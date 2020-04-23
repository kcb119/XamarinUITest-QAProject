using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private List<Usuario> oUsuarios = new List<Usuario>();
        public MainPage()
        {
            InitializeComponent();
            IniciarUsuarios();
            Iniciar();
        }

        private void Iniciar() 
        {
            btnPaginaRegistro.Clicked += BtnPaginaRegistro_Clicked;
            btnLogin.Clicked += BtnLogin_Clicked;
        }

        private void IniciarUsuarios()
        {
            Usuario oUsuario = new Usuario("111", "Lucia", "12345");
            this.oUsuarios.Add(oUsuario);
            oUsuario = new Usuario("222", "Daniel", "12345");
            this.oUsuarios.Add(oUsuario);
            oUsuario = new Usuario("333", "Diego", "12345");
            this.oUsuarios.Add(oUsuario);
        }

        private string BuscarUsuarioContrasena(string cedula, string contrasenna) 
        {
            string respuesta = "";

            foreach (Usuario item in this.oUsuarios)
            {
                if (cedula != item.cedula.ToString())
                {
                    respuesta = "usuario no existe";
                }
                else {
                    respuesta = "";
                    if (contrasenna != item.contrasenna.ToString())
                    {
                        respuesta = "pass invalida";
                    }
                    break;
                }
            }

            return respuesta;
        }

      

        private void BtnLogin_Clicked(object sender, EventArgs e)
        {
            string msg = "";
            lblError.Text = "";
            string cedula = txtCedula.Text;
            string contrasenna = txtContrasenna.Text;

            //validar usuario y contrasenna
            string respuesta = "";
            respuesta = this.BuscarUsuarioContrasena(cedula, contrasenna);
            if (respuesta == "usuario no existe")
            {
                msg = "usuario no existe";
                lblError.Text = msg;
            }
            if (respuesta == "pass invalida")
            {
                msg = "contraseña invalida";
                lblError.Text = msg;
            }
            if (respuesta == "")
            {
                msg = "Datos correctos";
                lblError.Text = msg;
                Navigation.PushAsync(new IniPage(cedula));
            }


        }

        private void BtnPaginaRegistro_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegistroPage());
        }
    }
}
