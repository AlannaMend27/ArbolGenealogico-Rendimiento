using System;
using System.Diagnostics;
using Arbol_Core.DataStructures;
using Arbol_Core.Models;

public class PruebaEstres
{
    public static void Run()
    {
        int N = 2000; // tamaño grande

        var grafo = new Grafo();
        var arbol = new Arbol();

        Persona p1 = null;
        Persona p2 = null;

        for (int i = 0; i < N; i++)
        {
            var p = new Persona(
                "Nombre",
                "Apellido",
                i.ToString(),
                DateTime.Now.AddYears(-20),
                20,
                10 + i,
                -84 + i,
                "",
                "familiar"
            );

            grafo.AgregarNodo(p);
            arbol.AgregarPersona(p);

            if (i == 0) p1 = p;
            if (i == 1) p2 = p;
        }

        var proceso = Process.GetCurrentProcess();

        var cpuAntes = proceso.TotalProcessorTime;
        long memAntes = GC.GetTotalMemory(true);

        var sw = Stopwatch.StartNew();

        // ===== STRESS =====

        for (int i = 0; i < 1000; i++)
        {
            p1.ObtenerErroresValidacion();
            p1.CalcularDistancia(p2);
            arbol.BuscarPorCedula(p1.Cedula);

            var nueva = new Persona(
                "Nuevo",
                "Apellido",
                Guid.NewGuid().ToString(),
                DateTime.Now.AddYears(-30),
                30,
                10,
                -84,
                "",
                "familiar"
            );

            arbol.AgregarPersona(nueva);
        }

        grafo.ConstruirAristas();
        grafo.ObtenerParMasLejano();
        grafo.ObtenerParMasCercano();

        sw.Stop();

        var cpuDespues = proceso.TotalProcessorTime;
        long memDespues = GC.GetTotalMemory(true);

        double cpuUsado = (cpuDespues - cpuAntes).TotalMilliseconds;
        long memoriaUsada = memDespues - memAntes;

        Console.WriteLine("===== STRESS TEST =====");
        Console.WriteLine("Cantidad de entrada: " + N);
        Console.WriteLine("Tiempo ms: " + sw.ElapsedMilliseconds);
        Console.WriteLine("CPU ms: " + cpuUsado);
        Console.WriteLine("Memoria bytes: " + memoriaUsada);
    }
}