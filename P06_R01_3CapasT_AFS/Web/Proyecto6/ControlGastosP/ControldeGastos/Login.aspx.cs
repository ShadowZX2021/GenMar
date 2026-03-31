using System;
using System.Web.UI;
using BLL;
using VO;

namespace ControlGastosWeb
{
    public partial class Login : Page
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
                    Session["Usuario"] = usuario.Email;

                    Response.Redirect("Menu.aspx"); // Usuarios.aspx si no tienes menú
                }
                else
                {
                    lblMensaje.Text = "Credenciales incorrectas";

                    // ANIMACIÓN ERROR
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "error", "animarError();", true);
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error: " + ex.Message;
            }
        }
    }
}