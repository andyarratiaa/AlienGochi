using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SeleccionarGorro : MonoBehaviour
{
    public GorroConfig configuracionGorros; // Asigna el ScriptableObject desde el Inspector
    public TMP_Text resultadoTexto;            // Texto de la UI para mostrar el resultado (opcional)
    public Image spriteRenderer;
    public Button[] botonesGorros;
    public bool[] gorrosDesbloqueados;
    public Image gorritoAlienUI;
    public Image gorritoAlien;

    void Start()
    {
        // Inicializamos los gorros desbloqueados como todos bloqueados
        gorrosDesbloqueados = new bool[configuracionGorros.gorros.Length];
        ActualizarBotones();
    }
    // Método que se llama desde el botón
    public void SeleccionarGorroBoton()
    {
        // Seleccionar un gorro aleatorio
        GorroConfig.Gorro gorroSeleccionado = SeleccionarGorroAleatorio();
        if (gorroSeleccionado != null)
        {
            string resultado = $"Gorro seleccionado: {gorroSeleccionado.nombre} ({gorroSeleccionado.rareza})";
            Debug.Log(resultado);
            resultadoTexto.text = resultado;
            spriteRenderer.sprite = gorroSeleccionado.spriteRenderer;
            // Verificamos si no lo teníamos desbloqueado
            int indiceGorro = BuscarIndiceGorro(gorroSeleccionado.nombre);
            if (indiceGorro >= 0 && !gorrosDesbloqueados[indiceGorro])
            {
                gorrosDesbloqueados[indiceGorro] = true;
                Debug.Log($"Gorro desbloqueado: {gorroSeleccionado.nombre}");
                ActualizarBotones();
            }
        }
    }
    private void ActualizarBotones()
    {
        for (int i = 0; i < botonesGorros.Length; i++)
        {
            if (i < gorrosDesbloqueados.Length)
            {
                botonesGorros[i].interactable = gorrosDesbloqueados[i];
            }
            else
            {
                botonesGorros[i].interactable = false;
            }
        }
    }
    private int BuscarIndiceGorro(string nombre)
    {
        for (int i = 0; i < configuracionGorros.gorros.Length; i++)
        {
            if (configuracionGorros.gorros[i].nombre == nombre)
            {
                return i;
            }
        }
        return -1;
    }

    public void SeleccionarGorroPorBoton(int indice)
    {
        if (indice >= 0 && indice < configuracionGorros.gorros.Length && gorrosDesbloqueados[indice])
        {
            string mensaje = $"Has seleccionado el gorro: {configuracionGorros.gorros[indice].nombre}";
            Debug.Log(mensaje);
            resultadoTexto.text = mensaje;
            gorritoAlien.sprite = configuracionGorros.gorros[indice].spriteRenderer;
            gorritoAlienUI.sprite = configuracionGorros.gorros[indice].spriteRenderer;
            Color colorActual = gorritoAlien.color;
            colorActual.a = Mathf.Clamp01(255);
            gorritoAlien.color = colorActual;
        }
        else
        {
            Debug.LogWarning("Este gorro no está desbloqueado.");
        }
    }
    GorroConfig.Gorro SeleccionarGorroAleatorio()
    {
        if (configuracionGorros == null || configuracionGorros.gorros.Length == 0)
        {
            Debug.LogWarning("No hay gorros configurados.");
            return null;
        }

        // Calcula el total de los pesos
        int totalPeso = 0;
        foreach (var gorro in configuracionGorros.gorros)
        {
            totalPeso += gorro.peso;
        }

        // Genera un número aleatorio entre 0 y el total de los pesos
        int numeroAleatorio = Random.Range(0, totalPeso);

        // Selecciona el gorro basado en el número aleatorio
        int acumulado = 0;
        foreach (var gorro in configuracionGorros.gorros)
        {
            acumulado += gorro.peso;
            if (numeroAleatorio < acumulado)
            {
                return gorro;
            }
        }

        return null; // Esto no debería pasar si los datos están correctos
    }
}