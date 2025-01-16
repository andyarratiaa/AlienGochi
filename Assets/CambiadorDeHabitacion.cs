using UnityEngine;
using System.Collections;

public class CambiadorDeHabitacion : MonoBehaviour
{

    public SpriteRenderer rendererHabitacion;
    public Sprite salonSprite;
    public Sprite cocinaSprite;
    public Sprite dormitorioSprite;

    public VirtualPet virtualPet;
    public byte queEstaHaciendo;
    public bool coroutining;

    private void Update()
    {
        

    }
    public void CambiarASalon()
    {
        rendererHabitacion.sprite = salonSprite;
    }
    public void CambiarACocina()
    {
        StartCoroutine(CambiarSpritePorUnSegundo(cocinaSprite, 1f));

    }

    public void CambiarADormitorio()
    {
        StartCoroutine(CambiarSpritePorUnSegundo(dormitorioSprite, 3.2f));

    }

    private IEnumerator CambiarSpritePorUnSegundo(Sprite spriteTemporal, float tiempo)
    {
        rendererHabitacion.sprite = spriteTemporal;
        yield return new WaitForSeconds(tiempo);
        rendererHabitacion.sprite = salonSprite;

    }
}
