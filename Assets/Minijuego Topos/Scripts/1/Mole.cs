using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mole : MonoBehaviour
{
    public bool GoUp;
    private float Speed = 4;
    public Vector3 StartP;
    public bool GoDown;
    public AudioClip Auch;

    void OnMouseDown()
    {
        Scoring.Score += 1;
        AudioSource.PlayClipAtPoint(Auch, new Vector3(0, 0, -10));
        Destroy(this.gameObject);
    }
    void Start()
    {
        GoDown = false;
        GoUp = true;
        StartP = transform.position;
    }

    IEnumerator Reset()
    {
        yield return new WaitForSeconds(1f);
        GoUp = false;
        GoDown = true;
    }

    void Update()
    {
        if (GoUp == false && transform.position.y > StartP.y && GoDown == true)
        {
            transform.Translate(Vector2.down * Speed * Time.deltaTime);
            if (transform.position.y < StartP.y)
            {
                Destroy(this.gameObject);
            }
        }
        if (GoUp == true && transform.position.y < StartP.y + 1.5f && GoDown == false)
        {
            transform.Translate(Vector2.up * Speed * Time.deltaTime);
            if (transform.position.y > StartP.y + 1.5f)
            {
                StartCoroutine(Reset());
            }
        }
    } 
}
