using UnityEngine; // Libreria de Unity a utilizar
using System.Threading; // Libreria del Sistema para utilizar hilos

public class ReallySlowTaskScript : MonoBehaviour
{
    public int result, timesToCompute, numberToMultiply; // Declaración de variables publicas enteras,
                                                         // se hacen publicas para poder modificar dentro de Unity.
                                                         // timesToCompute: cantidad de ocasiones que se obliga a la computadora a realizar la operación
                                                         // numberToMultiply: valor que se quiere multiplicar
    
    private bool abort = false; // Declaración de varible privada booleana 
    private Thread secondaryThread; // Declaración de variable privada tipo Thread para creación del hilo secundario

    void Start()
    {
        secondaryThread = new Thread(SlowTask); // Creación de hilo secundario en la variable secondaryThread,
                                                // el cual ejecuta la función SlowTask
        secondaryThread.Start(); // Se ejecuta el hilo secundario
    }

    void SlowTask() // Función que se ejecuta de manera muy lenta
    {
        while (true) // Hace que el hilo secundario no se deje de ejecutar (bucle infinito)
        {
            if (abort) // Si se aborta el hilo
            {
                secondaryThread.Abort(); // Para el hilo y deja de ejecutar la tarea
                break; // Forza la salida del while(true)
            }

            for(int i = 0; i < timesToCompute; i++) // Determina las veces que se ejecuta la operación
            {
                result = numberToMultiply * 2; // Realiza la operación de multiplicación, multiplica un valor * 2
            }
        }
    }

    private void OnApplicationQuit() // Función que se llama al cerrar la aplicación
    {
        abort = true; // Cambia el valor de la variable abort a verdadero para terminar el hilo secundario
    }
}