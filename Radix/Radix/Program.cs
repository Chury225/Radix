using System;
using System.Collections.Generic;
namespace RadixSort
{
    class Radix
    {
        public void RadixSort(int[] a)
        {
            // Este es nuestro arreglo auxiliar .
            int[] t = new int[a.Length];
            // Tamaño en bits de nuestro grupo. 
            // Intenta también 2, 8 o 16 para ver si es rápido o no.
            int r = 2;
            // Número de bits de un entero en c#. 
            int b = 32;
            // Inicia el conteo a asignación de los arreglos.
            // Notar dimensiones 2^r el cual es el número de todos los valores posibles de un número r-bit.
            int[] count = new int[1 << r];
            int[] pref = new int[1 << r];
            // Número de grupos. 
            int groups = (int)Math.Ceiling((double)b / (double)r);
            // Máscara para identificar los grupos.
            int mask = (1 << r) - 1;
            // Implementación del algoritmo 
            for (int c = 0, shift = 0; c < groups; c++, shift += r)
            {
                // Reiniciar el conteo en los arreglos.
                for (int j = 0; j < count.Length; j++)
                    count[j] = 0;
                // Contar elementos del c-vo grupo.
                for (int i = 0; i < a.Length; i++)
                    count[(a[i] >> shift) & mask]++;
                // Calculando prefijos.
                pref[0] = 0;
                for (int i = 1; i < count.Length; i++)
                    pref[i] = pref[i - 1] + count[i - 1];
                // De a[] a t[] elementos ordenados por c-vo grupo .
                for (int i = 0; i < a.Length; i++)
                    t[pref[(a[i] >> shift) & mask]++] = a[i];
                // a[]=t[] e inicia otra vez hasta el último grupo. 
                t.CopyTo(a, 0);
                Console.WriteLine("{0}", c);
            }
            // Está ordenado 	   
        }
        public static void Main(string[] args)
        {
            int[] a = new int[7] { 2, 3, 1, 0, 5, 6, 9 };
            Console.WriteLine("Ordenamiento Radix");
            Radix O = new Radix();
            O.RadixSort(a);
            Console.ReadLine();
        }
    }
}