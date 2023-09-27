using System;
using BCrypt.Net;
using System.Security;
using System.Resources;
using System.Threading;
using System.ComponentModel;
using System.IO.Compression;
using System.Threading.Tasks;
using System.Reflection.Metadata;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;


public static class Sesion{
    public static int GetEstadoSesion(HttpContext Context)
    {
        if (Context.Request.Cookies["logStatus"] != null)
        {
            if (int.TryParse(Context.Request.Cookies["logStatus"], out int estadoSesion))
            {
                return estadoSesion;
            }
        }
        return -2;
    }

    public static int IniciarSesion(string nombreusuario, string contrasena){
        Usuario user = BD.ObtenerUsuario(nombreusuario);
        if (user != null) {
            if (BCrypt.Net.BCrypt.Verify(contrasena, user.Contrasena)){
                return 1;
            } else {
                return 0;
            }
        } else {
            return -1;
        }
        return -1;
    }

    public static void CrearCuenta(string Usuario, string Contrasena, string Nombre, string Email, int idPregunta, string RespuestaPregunta){
        string hashContrasena = BCrypt.Net.BCrypt.HashPassword(Contrasena);
        BD.AgregarUsuario(new Usuario(Usuario, hashContrasena, Nombre, Email, idPregunta, RespuestaPregunta));
    }
}