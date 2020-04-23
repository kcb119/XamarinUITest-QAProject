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
    public partial class IniPage : ContentPage
    {
        private string cedula;
        private List<Usuario> oUsuarios = new List<Usuario>();

        public IniPage(string cedula)
        {
            InitializeComponent();
            IniciarUsuarios();
            this.cedula = cedula;
            lblError.Text = "";
            txtCedula.Text = cedula;
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
            btnEditarPerfil.Clicked += BtnEditarPerfil_Clicked;
            btnEliminarPerfil.Clicked += BtnEliminarPerfil_Clicked;
        }

        private void BtnEliminarPerfil_Clicked(object sender, EventArgs e)
        {
            for (int i = 0; i < this.oUsuarios.Count(); i++)
            {
                if (cedula == this.oUsuarios[i].cedula.ToString())
                {
                    this.oUsuarios.RemoveAt(i);
                }
                
            }
            Navigation.PushAsync(new MainPage());
        }

        private void BtnEditarPerfil_Clicked(object sender, EventArgs e)
        {
            string cedula = txtCedula.Text;
            string correo = txtCorreo.Text;
            string contrasenna = txtContrasenna.Text;
            lblError.Text = "";
            lblExito.Text = "";

            if (cedula != this.cedula)
            {
                lblError.Text = "la cédula no se puede cambiar";
            }
            else if (cedula == "" || correo == "" || contrasenna == "")
            {
                lblError.Text = "datos incompletos";

            }
            else {
                lblExito.Text = "información actualizada";
            }
            
        }




    }
}