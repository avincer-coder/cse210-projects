using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Palabra
{
    public string Texto { get; private set; }
    
    public Palabra(string texto)
    {
        Texto = texto;
    }

    // Método que reemplaza la palabra por guiones bajos
    public void Esconder()
    {
        Texto = new string('_', Texto.Length);
    }

    // Devuelve el texto de la palabra
    public override string ToString()
    {
        return Texto;
    }

    // Verifica si la palabra está oculta (solo guiones bajos)
    public bool EstaOculta()
    {
        return Texto.All(c => c == '_');
    }
}

class Escritura
{
    private string contenidoOriginal;
    private List<Palabra> palabras;

    public Escritura(string contenido)
    {
        contenidoOriginal = contenido;
        palabras = contenido.Split(' ').Select(p => new Palabra(p)).ToList();
    }

    // Esconde una cantidad específica de palabras
    public bool EsconderPalabras(int cantidad)
    {
        var palabrasDisponibles = palabras.Where(p => !p.EstaOculta()).ToList();
        if (palabrasDisponibles.Count == 0) return false;

        Random rand = new Random();
        HashSet<int> indicesSeleccionados = new HashSet<int>();

        while (indicesSeleccionados.Count < Math.Min(cantidad, palabrasDisponibles.Count))
        {
            int index = palabras.IndexOf(palabrasDisponibles[rand.Next(palabrasDisponibles.Count)]);
            indicesSeleccionados.Add(index);
        }

        foreach (int index in indicesSeleccionados)
        {
            palabras[index].Esconder();
        }

        return true;
    }

    // Obtiene el contenido actual con palabras ocultas
    public string ObtenerContenido()
    {
        return string.Join(" ", palabras);
    }

    // Obtiene el contenido original sin modificaciones
    public string ObtenerContenidoOriginal()
    {
        return contenidoOriginal;
    }
}

class Referencia
{
    public string Numero { get; }
    public string Ubicacion { get; }

    public Referencia(string numero, string ubicacion)
    {
        Numero = numero;
        Ubicacion = ubicacion;
    }

    public override string ToString() => $"Referencia {Numero}: {Ubicacion}";
}

class Programa
{
    private Escritura escritura;
    private Referencia referencia;

    public Programa(string archivoPath)
    {
        var lineas = File.ReadAllLines(archivoPath);
        if (lineas.Length < 3)
        {
            throw new Exception("El archivo no tiene suficiente contenido.");
        }

        Random rand = new Random();
        int index = rand.Next(0, lineas.Length / 3) * 3;
        referencia = new Referencia(lineas[index].Trim('"'), archivoPath);
        escritura = new Escritura(string.Join(" ", lineas.Skip(index + 1).Take(2)));
    }

    public void MostrarMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine(referencia);
            Console.WriteLine(escritura.ObtenerContenido());
            Console.WriteLine("\nOpciones:");
            Console.WriteLine("1. Esconder 3 palabras");
            Console.WriteLine("2. Mostrar escritura original");
            Console.WriteLine("Escribe 'quit' para salir.");

            string opcion = Console.ReadLine()?.Trim().ToLower();

            switch (opcion)
            {
                case "quit":
                    return;
                case "1":
                    if (!escritura.EsconderPalabras(3))
                    {
                        Console.WriteLine("Toda la escritura ha sido ocultada.");
                        Console.ReadLine();
                    }
                    break;
                case "2":
                    Console.WriteLine("\nTexto original:");
                    Console.WriteLine(escritura.ObtenerContenidoOriginal());
                    Console.WriteLine("\nPresiona Enter para continuar...");
                    Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("Opción no válida, intenta nuevamente.");
                    Console.ReadLine();
                    break;
            }
        }
    }
}

class Program
{
    static void Main()
    {
        string rutaArchivo = "escritura.txt";
        if (!File.Exists(rutaArchivo))
        {
            Console.WriteLine("Archivo no encontrado.");
            return;
        }

        try
        {
            Programa programa = new Programa(rutaArchivo);
            programa.MostrarMenu();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
