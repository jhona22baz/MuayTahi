using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Muay_tahi_administrator
{
    public partial class Login : Form
    {
        FigthersEntities db;
        public Login()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string nickname = txtNickname.Text;
            string password = txtPassword.Text;
            if (nickname == "" || password == "")
            {
                lblMensaje.Text = "Es necesario que ingreses usuario y/o contraseña";
            }
            else
            {
                db = new FigthersEntities();
                Usuario user = new Usuario();
                try
                {
                    var context = new FigthersEntities();
                    //var users = from Usuario in context.Usuario select user;
                    user = db.Usuario.FirstOrDefault(a => a.nickname == nickname && a.passwork == password);
                    if (user == null)
                    {
                        lblMensaje.Text = "No existe el Usuario en el sistema";
                    }
                    else
                    {
                        DialogResult = DialogResult.OK;
                    }
                }
                catch (EntitySqlException ex)
                {
                    MessageBox.Show(":( Ocurrio un pequeño error vuelve a intentarlo..... {0}", ex.Message);
                }

            }
        }
       
    }
}
