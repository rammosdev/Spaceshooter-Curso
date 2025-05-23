using UnityEngine;

public class MusicMenu : MonoBehaviour
{
    [SerializeField] private AudioClip mainTheme;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TocaMusica();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TocaMusica()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = mainTheme;
        audio.loop = true;
        audio.Play();
    }
}
