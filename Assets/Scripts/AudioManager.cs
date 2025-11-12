using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public AudioSource titleMusic;
    public AudioSource[] bgMusic;

    public AudioSource[] sfx;
    private int currentTrack;

    private bool isPaused;
    private void Start()
    {
        currentTrack = -1;
    }

    private void Update()
    {
        if (isPaused == false)
        {
            // Protection contre tableau vide / index invalide
            if (bgMusic == null || bgMusic.Length == 0)
                return;

            // Si l'index est hors bornes (ex: -1 au démarrage) ou le track courant n'est pas en lecture, avancer
            if (currentTrack < 0 || currentTrack >= bgMusic.Length || bgMusic[currentTrack] == null || bgMusic[currentTrack].isPlaying == false)
            {
                PlayNextBGM();
            }
        }
    }

    public void StopMusic()
    {
        if (bgMusic != null)
        {
            foreach (AudioSource track in bgMusic)
            {
                if (track != null)
                    track.Stop();
            }
        }

        if (titleMusic != null)
            titleMusic.Stop();
    }

    public void PlayTitle()
    {
        StopMusic();
        if (titleMusic != null)
            titleMusic.Play();
    }

    public void PlayNextBGM()
    {
        if (bgMusic == null || bgMusic.Length == 0)
            return;

        StopMusic();

        currentTrack++;
        if (currentTrack >= bgMusic.Length)
        {
            currentTrack = 0;
        }

        if (bgMusic[currentTrack] != null)
            bgMusic[currentTrack].Play();
    }

    public void PauseMusic()
    {
        isPaused = true;

        if (bgMusic == null || bgMusic.Length == 0 || currentTrack < 0 || currentTrack >= bgMusic.Length)
            return;

        if (bgMusic[currentTrack] != null)
            bgMusic[currentTrack].Pause();
    }
    public void ResumeMusic()
    {
        isPaused = false;

        if (bgMusic == null || bgMusic.Length == 0 || currentTrack < 0 || currentTrack >= bgMusic.Length)
            return;

        if (bgMusic[currentTrack] != null)
            bgMusic[currentTrack].UnPause();
    }

    public void PlaySFX(int sfxToPlay)
    {
        if (sfx == null || sfxToPlay < 0 || sfxToPlay >= sfx.Length)
            return;

        if (sfx[sfxToPlay] != null)
        {
            sfx[sfxToPlay].Stop();
            sfx[sfxToPlay].Play();
        }
    }

    public void PlaySFXPitchAdjusted(int sfxToPlay)
    {
        if (sfx == null || sfxToPlay < 0 || sfxToPlay >= sfx.Length || sfx[sfxToPlay] == null)
            return;

        sfx[sfxToPlay].pitch = Random.Range(.8f, 1.2f);

        PlaySFX(sfxToPlay);
    }
}
