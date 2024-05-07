using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    public AudioSource[] specificClips;

    private float basePitch = 1.0f;
    private float pitchIncrement = 0.05f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
            return;
        }
    }

    public void PlaySpecificClip(int clipIndex)
    {
        if (clipIndex >= 0 && clipIndex < specificClips.Length)
        {
            specificClips[clipIndex].Play();
        }
        else
        {
            Debug.LogWarning("Audio clip index out of range");
        }
    }

    public void PlayHitSound()
    {
        float treshold = 0.5f;

        if (Random.Range(0f, 1f) > treshold)
        {
            PlaySpecificClip(0);
            Debug.Log("Biep");
        }
        else
        {
            PlaySpecificClip(1);
            Debug.Log("Bop");
        }
    }

    public void IncreasePitch()
    {
        basePitch += pitchIncrement;
    }
}
