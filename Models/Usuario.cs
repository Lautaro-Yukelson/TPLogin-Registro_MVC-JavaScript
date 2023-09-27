public class Usuario{
    public int idUsuario {get; set;}
    public string NombreUsuario {get; set;}
    public string Contrasena {get; set;}
    public string Nombre {get; set;}
    public string Email {get; set;}
    public int idPregunta {get; set;}
    public string RespuestaPregunta {get; set;}

    public Usuario(){}

    public Usuario(string nombreusuario, string contrasena, string nombre, string email, int idpregunta, string respuestapregunta){
        NombreUsuario = nombreusuario;
        Contrasena = contrasena;
        Nombre = nombre;
        Email = email;
        idPregunta = idpregunta;
        RespuestaPregunta = respuestapregunta;
    }
}