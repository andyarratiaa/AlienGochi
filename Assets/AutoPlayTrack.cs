using UnityEngine;

public class AutoPlayTrack : MonoBehaviour
{
    public AudioClip track;
    private AudioSource audioSource;
    public float volume = 1f;

    void Awake()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = track;
        audioSource.loop = true;
        audioSource.playOnAwake = false;

    }
    private void Update()
    {
        audioSource.volume = volume;
    }

    void OnEnable()
    {
        if (track != null)
        {
            audioSource.Play();
        }
    }

    void OnDisable()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}
