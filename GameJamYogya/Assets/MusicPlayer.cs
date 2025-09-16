using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioClip backgroundMusic;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = backgroundMusic;
        audioSource.loop = true;       // biar terus muter
        audioSource.playOnAwake = true;
        audioSource.volume = 0.5f;     // atur volume 0 - 1
        audioSource.Play();
    }
}
