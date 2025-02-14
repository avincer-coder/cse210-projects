using System;
using System.Collections.Generic;

class Video
{
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public int Duracion { get; set; } // Duración en segundos
    public List<Comment> Comentarios { get; set; } = new List<Comment>();

    public Video(string titulo, string autor, int duracion)
    {
        Titulo = titulo;
        Autor = autor;
        Duracion = duracion;
    }

    public int ObtenerNumeroComentarios()
    {
        return Comentarios.Count;
    }
}

class Comment
{
    public string Nombre { get; set; }
    public string Texto { get; set; }

    public Comment(string nombre, string texto)
    {
        Nombre = nombre;
        Texto = texto;
    }
}

class CreateVideo
{
    public static void Ejecutar()
    {
        List<Video> videos = new List<Video>
        {
            new Video("Aprendiendo C#", "Juan Pérez", 600),
            new Video("POO en C#", "María López", 750),
            new Video("Estructuras de Datos", "Carlos Sánchez", 900),
            new Video("Algoritmos Básicos", "Ana Rodríguez", 800)
        };

        foreach (var video in videos)
        {
            video.Comentarios.Add(new Comment("Pedro", "Muy buen video, gracias!"));
            video.Comentarios.Add(new Comment("Luis", "Me ayudó bastante."));
            video.Comentarios.Add(new Comment("Elena", "Explicación clara y concisa."));
            video.Comentarios.Add(new Comment("Sofía", "Espero más contenido así!"));
        }

        foreach (var video in videos)
        {
            Console.WriteLine($"Título: {video.Titulo}\nAutor: {video.Autor}\nDuración: {video.Duracion} segundos\nComentarios: {video.ObtenerNumeroComentarios()}\n");
            
            foreach (var comentario in video.Comentarios)
            {
                Console.WriteLine($"    - {comentario.Nombre}: {comentario.Texto}");
            }
            Console.WriteLine();
        }
    }
}

class Program
{
    public static void Main()
    {
        CreateVideo.Ejecutar();
    }
}
