using UnityEngine;

public class SpriteRotationToggle : MonoBehaviour
{
    private bool isRotated = false;

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            isRotated = true;
            ToggleRotation();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isRotated = false;
            ToggleRotation();
        }
    }

    private void ToggleRotation()
    {
        if (isRotated)
        {
            transform.rotation = Quaternion.Euler(0, 0, 210);

        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);

        }


    }
}

