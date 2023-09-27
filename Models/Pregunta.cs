public class Pregunta{
    public int idPregunta {get; set;}
    public string Enunciado {get; set;}

    public Pregunta(){}

    public Pregunta(string enunciado){
        Enunciado = enunciado;
    }
}