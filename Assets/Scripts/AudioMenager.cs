using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMenager : MonoBehaviour
{
    public AudioSource MusicSource;
    public AudioClip[] musics;
    public static AudioMenager instanciate = null;
    public int index = 0;
    void Start()
    {
        MusicSource = GetComponent<AudioSource>();
        if (instanciate == null)
        {
            instanciate = this;
        }
        MusicSource.clip = musics[index];
        MusicSource.Play();
    }
    private void Update()
    {
        if (!MusicSource.isPlaying)
        {
            setMusic();
        }
    }
    public void setMusic()
    { 
        index += 1;
        if(index > musics.Length)
        {
            index = 0;
        }
        MusicSource.clip = musics[index];
        MusicSource.Play();
    }
    public static AudioSource CreateNewSource(string _name)
	{
		AudioSource newSource = new GameObject(_name).AddComponent<AudioSource>();
		newSource.transform.SetParent(instanciate.transform);
		return newSource;
	}
    public void muteMusic()
    {
        MusicSource.mute = true;
    }
    public void playMusic()
    {
        MusicSource.mute = false;
    }
    public void PlaySFX(AudioClip effect, float volume = 1f, float pitch = 1f)
	{
		AudioSource source = CreateNewSource(string.Format("SFX [{0}]", effect.name));
		source.clip = effect;
		source.volume = volume;
		source.pitch = pitch;
		source.Play();

		Destroy(source.gameObject, effect.length);
	}
}
