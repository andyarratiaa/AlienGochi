using System.Collections;
using UnityEngine;

public class Hoyo : MonoBehaviour
{
    public Vector2 startPosition = new Vector2(0f, -3.1f);
    public Vector2 endPosition = Vector2.zero;
    public float showDuration = 0.5f;
    public float duration = 1f;

    private IEnumerator ShowHide(Vector2 start, Vector2 end) 
    {
        transform.localPosition = start;

        float elapsed = 0f;
        while (elapsed < showDuration) 
        {
            transform.localPosition = Vector2.Lerp(start, end, elapsed / showDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = end;

        yield return new WaitForSeconds(duration);

        elapsed = 0f;
        while (elapsed < showDuration) 
        {
            transform.localPosition = Vector2.Lerp(end, start, elapsed / showDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = start;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        StartCoroutine(ShowHide(startPosition, endPosition));
    }
}
