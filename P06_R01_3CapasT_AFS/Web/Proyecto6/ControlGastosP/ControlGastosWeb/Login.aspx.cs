using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BLL;
using VO;

namespace ControlGastosWeb
{
    public partial class Login : System.Web.UI.Page
    {
        B_Usuarios negocio = new B_Usuarios();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            V_Usuarios usuario = new V_Usuarios()
            {
                Email = txtEmail.Text.Trim(),
                Password = txtPassword.Text.Trim()
            };

            try
            {
                if (negocio.Login(usuario))
                {
                    // Guardar sesión
                    Session["Usuario"] = usuario.Email;

                    Response.Redirect("Usuarios.aspx");
                }
                else
                {
                    lblMensaje.Text = "Credenciales incorrectas";
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error: " + ex.Message;
            }
        }
    }
}