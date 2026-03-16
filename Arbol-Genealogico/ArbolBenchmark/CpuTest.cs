using System;
using System.Diagnostics;
using Arbol_Core.DataStructures;
using Arbol_Core.Models;

public class CpuTest
{
    public static void Run()
    {
        int N = 200;

        var grafo = new Grafo();

        for (int i = 0; i < N; i++)
        {
            var p = new Persona(
                "Nombre",
                "Apellido",
                i.ToString(),
                DateTime.Now,
                20,
                10 + i * 0.01,
                -84 + i * 0.01,
                "",
                "familiar"
            );

            grafo.AgregarNodo(p);
        }

        var proceso = Process.GetCurrentProcess();

        var cpuAntes = proceso.TotalProcessorTime;
        long memAntes = GC.GetTotalMemory(true);

        var sw = Stopwatch.StartNew();

        grafo.ConstruirAristas();
        grafo.CalcularDistanciaPromedio();
        grafo.ObtenerParMasLejano();
        grafo.ObtenerParMasCercano();

        sw.Stop();

        var cpuDespues = proceso.TotalProcessorTime;
        long memDespues = GC.GetTotalMemory(true);

        double cpuUsado = (cpuDespues - cpuAntes).TotalMilliseconds;
        long memoriaUsada = memDespues - memAntes;

        Console.WriteLine("Tiempo real ms: " + sw.ElapsedMilliseconds);
        Console.WriteLine("CPU ms: " + cpuUsado);
        Console.WriteLine("Memoria bytes: " + memoriaUsada);
    }
}