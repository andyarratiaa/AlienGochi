using UnityEngine;

[CreateAssetMenu(fileName = "GorroConfig", menuName = "Scriptable Objects/GorroConfig")]
public class GorroConfig : ScriptableObject
{
    [System.Serializable]
    public class Gorro
    {
        public string nombre; // Nombre del gorro
        public string rareza; // Rareza (Normal, Raro, Legendario)
        public int peso;      // Peso para el sistema de probabilidades
        public Sprite spriteRenderer;
    }

    public Gorro[] gorros; // Lista de gorros
}
