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
    
    public partial class Principal : Form
    {
        BaseDatosAcciones bd;        
        FigthersEntities context;


        public Principal()
        {
            InitializeComponent();
            RefreshDataBinding();
        }

        private void RefreshDataBinding()
        {
            context = new FigthersEntities();
            var query = from a in context.Alumno
                        select new DataBindingProjection { AlumID = a.Id, AlumName = a.nombre, AlumnfechaPago = a.fechaPago };
            var alums = query.ToList();
            dgvDatos.DataSource = alums;
        }
        private void cleantextbox()
        {
            txtId.Text = "";
            txtName.Text = "";
            txtLastName.Text = "";
            txtPay.Text = "";
            txtdebe.Text = "";
            dtFechaPago.Value = DateTime.Now;
        }
        private bool revisartextox() 
        {
            if (txtId.Text == "")return false;
            else if (txtName.Text == "") return false;
            else if (txtLastName.Text != "") return false;
            else if (txtPay.Text == "") return false;
            else if (txtdebe.Text == "") return false;
            else { return true; }
        }

        #region Botonoes 
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            bool ok;
            bd = new BaseDatosAcciones();
            if (txtId.Text != "")
            {
                ok = bd.SearchAlumn(int.Parse(txtId.Text));
                if (ok == true)
                {
                    txtName.Text = bd.other.nombre;
                    txtLastName.Text = bd.other.apellido;
                    txtPay.Text = bd.other.pago.ToString();
                    txtdebe.Text = bd.other.debe.ToString();
                    dtFechaPago.Value = bd.other.fechaPago;

                }
                else { lblMensaje.Text = "el Alumno no existe u ocurrio un error al buscarlo."; }
            }
            else {
                lblMensaje.Text = "Es necesario agregar un Id para buscar";
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            bool ok;
            bd = new BaseDatosAcciones();
            if (revisartextox())
            {
                ok = bd.AddAlumn(int.Parse(txtId.Text), txtName.Text, txtLastName.Text, double.Parse(txtPay.Text),double.Parse(txtdebe.Text) ,dtFechaPago.Value);
                if (ok == true)
                {
                    lblMensaje.Text = "Se agrego el Alumno";
                    RefreshDataBinding();
                    cleantextbox();
                }
                else {
                    lblMensaje.Text = "Ocurrio algun error y no se puede agregar el alumno";
                }
            }
            else {
                lblMensaje.Text = "Debe de llenar todos los datos para agregar a un alumno";
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            bool ok;
            bd = new BaseDatosAcciones();
            if (txtId.Text != "")
            {
                ok = bd.DeleteAlumn(int.Parse(txtId.Text));
                if (ok == true) 
                {
                    lblMensaje.Text = "Alumno eliminado";
                    RefreshDataBinding();                                       
                    cleantextbox();
                }
            }
            else {
                lblMensaje.Text = "es necesario un Id de alumno";
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            bool ok;
            bd = new BaseDatosAcciones();
            if (revisartextox())
            {
                ok = bd.Actualizar(int.Parse(txtId.Text), txtName.Text, txtLastName.Text, double.Parse(txtPay.Text), double.Parse(txtdebe.Text), dtFechaPago.Value);
                if (ok == true)
                {
                    lblMensaje.Text = "Se actualizo la informacion del alumno";
                    RefreshDataBinding();
                    cleantextbox();
                }
                else { lblMensaje.Text = "el Alumno no existe u ocurrio un error al buscarlo."; }
            }
            else {                
                lblMensaje.Text ="Debe de llenar todos los datos para guardar cambios";
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            cleantextbox();
            RefreshDataBinding();
        
        }
        #endregion       

        #region key_Press
        private void txtId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        

        private void txtPay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtLastName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        #endregion

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }

    public class DataBindingProjection
    {
        public int AlumID { get; set; }
        public string AlumName { get; set; }        
        public DateTime AlumnfechaPago { get; set; }        
    }
}
