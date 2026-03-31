using DAL;
using System;
using System.Collections.Generic;
using VO;

namespace BLL
{
    public class B_Usuarios
    {
        private D_Usuarios datos = new D_Usuarios();
        public List<V_Usuarios> Listar()
        {
            return datos.ListarUsuarios();
        }

        public string InsertarUsuario(V_Usuarios usuarios)
        {
            try
            {
                if (string.IsNullOrEmpty(usuarios.Nombre))
                    return "El nombre de usuaro es obligatorio";
                if (string.IsNullOrEmpty(usuarios.Email))
                    return "El email es obligatorio";
                if (string.IsNullOrEmpty(usuarios.Password))
                    return "El password es obligatorio";
                if (datos.ExisteEmail(usuarios.Email))
                    return "Ya existe un usuario con este email";
                if (datos.ExisteUsuario(usuarios.IdDatos))
                    return "Ya existe un usuario con este nombre";

                if (datos.InsertarUsuario(usuarios))
                    return "OK";
                else
                    return "No se inserto el usuario";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }

        public string ActualizarUsuario(V_Usuarios usuarios)
        {
            try
            {
                if (string.IsNullOrEmpty(usuarios.Nombre))
                    return "El nombre de usuaro es obligatorio";
                if (string.IsNullOrEmpty(usuarios.Email))
                    return "El email es obligatorio";
                if (string.IsNullOrEmpty(usuarios.Password))
                    return "El password es obligatorio";
                if (usuarios.IdUsuario <= 0)
                    return "Usuario invalido";

                if (datos.ActualizarUsuario(usuarios))
                    return "OK";
                else
                    return "No se pudo actualizar el usuario";
            }
            catch (Exception ex) { 
                return "Error: "+ex.Message;
            }
        }

        public string EliminarUsuario(int idUsuario)
        {
            try
            {
                if (datos.EliminarUsuario(idUsuario))
                    return "OK";
                else
                    return "No se pudo eliminar el usuario";

            }
            catch (Exception ex)
            {

                return "Error: " + ex.Message;
            }
        }

        public bool Login(V_Usuarios usuarios)
        {
             if(string.IsNullOrEmpty(usuarios.Email) || string.IsNullOrEmpty(usuarios.Password))
                throw new Exception("Datos incompletos");
            else
                return datos.LoginUsuario(usuarios);
        }

        public V_Usuarios ObtenerPorId(int idUsuario)
        {
            return datos.ObtenerUsuarioID(idUsuario);
        }

        public List<V_Usuarios> DropListDP()
        {
            return datos.DropListDatosPersonales();
        }
    }
}
