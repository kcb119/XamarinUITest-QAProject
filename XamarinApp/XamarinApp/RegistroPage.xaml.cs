using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistroPage : ContentPage
    {
        private List<Usuario> oUsuarios = new List<Usuario>();
        public RegistroPage()
        {
            InitializeComponent();
            IniciarUsuarios();
            Iniciar();
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

        private void Iniciar() 
        {
            btnRegistrar.Clicked += BtnRegistrar_Clicked;
        }

        private Boolean verificarCedula(string cedula) {
            Boolean resultado = false;

            foreach (Usuario item in this.oUsuarios)
            {
                if (cedula == item.cedula.ToString())
                {                    
                    resultado = true;
                    break;
                }
            }

            return resultado;
        }

        private void BtnRegistrar_Clicked(object sender, EventArgs e)
        {
            string cedula = txtCedula.Text;
            string correo = txtCorreo.Text;
            string contrasenna = txtContrasenna.Text;
            Boolean resultadoCedula = this.verificarCedula(cedula);
           



            if (cedula == "" || correo == "" || contrasenna == "")
            {
                lblRegistroIncompleto.Text = "datos incompletos";
                lblRegistroExito.Text = "";
                lblRegistroCedula.Text = "";
            }
            else if (resultadoCedula)
            {
                lblRegistroCedula.Text = "el usuario existe previamente";
                lblRegistroIncompleto.Text = "";
                lblRegistroExito.Text = "";

            }
            else {
                lblRegistroCedula.Text = "";
                lblRegistroIncompleto.Text = "";
                lblRegistroExito.Text = "usuario creado exitosamente";
            }

        }//Fin de metodo BtnRegistrar



    }
}