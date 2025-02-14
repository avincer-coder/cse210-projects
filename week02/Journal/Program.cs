using System;
using System.Collections.Generic;
using 
System.IO
;

class Anecdotas
{
    public List<string> userAnectotas = new List<string>();

    public void CrearAnecdota()
    {
        string[] preguntas = {
            "Who did you talk to today?", 
            "What did you do today?", 
            "At what time during the day?", 
            "Where did this take place?", 
            "Did you help someone today?"
        };

        Random random = new Random();
        int randomNumber = 
random.Next
(0, preguntas.Length);
        Console.WriteLine(preguntas[randomNumber]);

        string respuestaPregunta = Console.ReadLine();
        string fecha = DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss");

        string anecdotaCompleta = $"{fecha} - {preguntas[randomNumber]} - {respuestaPregunta}";
        userAnectotas.Add(anecdotaCompleta);

        Console.WriteLine("¡Anécdota guardada!");
        LeerTodasAnecdotas();
    }

    public void LeerTodasAnecdotas()
    {
        Console.WriteLine("\nAnécdotas registradas");
        foreach (var anecdota in userAnectotas)
        {
            Console.WriteLine(anecdota);
        }
    }
}

class Menu
{
    public void MostrarMenu()
    {
        Console.WriteLine("\nMain Menu - Choose an option :");
        Console.WriteLine("1. Write a new entry");
        Console.WriteLine("2. Display the journal");
        Console.WriteLine("3. Save the journal to a file");
        Console.WriteLine("4. Load the journal from a file");
        Console.WriteLine("5. Exit program");
    }
}

class Csv
{
    public void GuardarCsv(List<string> textoAnectotas)
    {
        using (StreamWriter writer = new StreamWriter("Archivo.csv", true))
        {
            foreach (string anecdota in textoAnectotas)
            {
                writer.WriteLine(anecdota);
            }
        }
        Console.WriteLine("Se han guardado las anécdotas en el archivo.");
    }

    public void LeerCsv()
    {
        if (File.Exists("Archivo.csv"))
        {
            Console.WriteLine("\nAnécdotas guardadas en el archivo");
            using (StreamReader reader = new StreamReader("Archivo.csv"))
            {
                string linea;
                while ((linea = reader.ReadLine()) != null)
                {
                    Console.WriteLine(linea);
                }
            }
        }
        else
        {
            Console.WriteLine("No se ha encontrado un archivo CSV con anécdotas.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Menu menu = new Menu();
        Anecdotas anecdota = new Anecdotas();
        Csv guardar = new Csv();

        while (true)
        {
            menu.MostrarMenu();
            string respuesta = Console.ReadLine();

            if (respuesta == "1")
            {
                anecdota.CrearAnecdota();
            }
            else if (respuesta == "2")
            {
                anecdota.LeerTodasAnecdotas();
            }
            else if (respuesta == "3")
            {
                guardar.GuardarCsv(anecdota.userAnectotas);
            }
            else if (respuesta == "4")
            {
                guardar.LeerCsv();
            }
            else
            {
                Console.WriteLine("EXIT PROGRAM");
                break;
            }
        }
    }
} 
