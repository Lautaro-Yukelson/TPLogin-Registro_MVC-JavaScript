using System.Reflection.Metadata;
using System;
using Dapper;
using System.Data;
using System.Linq;
using System.Threading;
using System.Data.Common;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Reflection.Metadata.Ecma335;


public static class BD
{
    private static string _connectionString = "Server=localhost;DataBase=LoginRegister;Trusted_Connection=True;";

    public static List<Pregunta> ObtenerPreguntas(){
        string sql = "SELECT * FROM Preguntas";
        using (SqlConnection db = new SqlConnection(_connectionString)){
            return db.Query<Pregunta>(sql).ToList();
        }
    }

    public static Usuario ObtenerUsuario(string nombreusuario){
        string sql = "SELECT * FROM Usuarios WHERE NombreUsuario = @nombreusuario";
        using (SqlConnection db = new SqlConnection(_connectionString)){
            return db.QueryFirstOrDefault<Usuario>(sql, new {nombreusuario});
        }
    }

    public static void AgregarUsuario(Usuario user){
        string sql = "INSERT INTO Usuarios (NombreUsuario, Contrasena, Nombre, Email, idPregunta, RespuestaPregunta) VALUES (@NombreUsuario, @Contrasena, @Nombre, @Email, @idPregunta, @RespuestaPregunta)";
        using (SqlConnection db = new SqlConnection(_connectionString)){
            db.Execute(sql, new {user.NombreUsuario, user.Contrasena, user.Nombre, user.Email, user.idPregunta, user.RespuestaPregunta});
        }
    }
}