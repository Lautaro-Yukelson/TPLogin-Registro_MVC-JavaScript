using System.Linq.Expressions;
using System;
using System.Security.Permissions;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TPLogin_Registro_MVC_JavaScript.Models;

namespace TPLogin_Registro_MVC_JavaScript.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        ViewBag.EstadoSesion = Sesion.GetEstadoSesion(HttpContext);
        return View();
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult LoginForm(string NombreUsuario, string Contrasena){
        int log = Sesion.IniciarSesion(NombreUsuario, Contrasena);
        CookieOptions logStatus = new CookieOptions { Expires = DateTime.Now.AddDays(7) };
        Response.Cookies.Append("logStatus", log.ToString(), logStatus);
        if (log == 1){
            return RedirectToAction("Index", "Home");
        } else {
            return RedirectToAction("Login", "Home");
        }
    }

    public IActionResult Register()
    {
        ViewBag.Preguntas = BD.ObtenerPreguntas();
        return View();
    }

    [HttpPost]
    public IActionResult RegisterForm(string NombreUsuario, string Contrasena, string Nombre, string Email, int idPregunta, string RespuestaPregunta){
        Sesion.CrearCuenta(NombreUsuario, Contrasena, Nombre, Email, idPregunta, RespuestaPregunta);
        return RedirectToAction("Index", "Home");
    }

    public IActionResult Olvide()
    {
        ViewBag.Preguntas = BD.ObtenerPreguntas();
        return View();
    }

    [HttpPost]
    public IActionResult ResetPsw(string username, int idPregunta, string respuesta){
        Usuario user = BD.ObtenerUsuario(username);
        if (user != null){
            if (user.idPregunta == idPregunta && user.RespuestaPregunta == respuesta){
                ViewBag.Usuario = user;
                return View();
            }
        }
        return RedirectToAction("Olvide", "Home");
    }

    [HttpPost]
    public IActionResult Reset(int idUsuario, string password){
        string hashContrasena = BCrypt.Net.BCrypt.HashPassword(password);
        BD.EditarContrasena(idUsuario, hashContrasena);
        return RedirectToAction("Login", "Home");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
