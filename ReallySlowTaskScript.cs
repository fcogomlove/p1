using UnityEngine; // Libreria de Unity a utilizar
using System.Threading; // Libreria del Sistema para utilizar hilos

public class ReallySlowTaskScript : MonoBehaviour
{
    public int result, timesToCompute, numberToMultiply; // Declaraci�n de variables publicas enteras,
                                                         // se hacen publicas para poder modificar dentro de Unity.
                                                         // timesToCompute: cantidad de ocasiones que se obliga a la computadora a realizar la operaci�n
                                                         // numberToMultiply: valor que se quiere multiplicar
    
    private bool abort = false; // Declaraci�n de varible privada booleana 
    private Thread secondaryThread; // Declaraci�n de variable privada tipo Thread para creaci�n del hilo secundario

    void Start()
    {
        secondaryThread = new Thread(SlowTask); // Creaci�n de hilo secundario en la variable secondaryThread,
                                                // el cual ejecuta la funci�n SlowTask
        secondaryThread.Start(); // Se ejecuta el hilo secundario
    }

    void SlowTask() // Funci�n que se ejecuta de manera muy lenta
    {
        while (true) // Hace que el hilo secundario no se deje de ejecutar (bucle infinito)
        {
            if (abort) // Si se aborta el hilo
            {
                secondaryThread.Abort(); // Para el hilo y deja de ejecutar la tarea
                break; // Forza la salida del while(true)
            }

            for(int i = 0; i < timesToCompute; i++) // Determina las veces que se ejecuta la operaci�n
            {
                result = numberToMultiply * 2; // Realiza la operaci�n de multiplicaci�n, multiplica un valor * 2
            }
        }
    }

    private void OnApplicationQuit() // Funci�n que se llama al cerrar la aplicaci�n
    {
        abort = true; // Cambia el valor de la variable abort a verdadero para terminar el hilo secundario
    }
}