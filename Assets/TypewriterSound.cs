using UnityEngine;
using UnityEngine.Audio;

public class TypewriterSound : MonoBehaviour
{
	public Sound[] sounds;
	public AudioMixerGroup audioMixer;

	void Awake()
	{
		foreach(Sound sound in sounds)
		{
			sound.source = gameObject.AddComponent<AudioSource>();
			sound.source.clip = sound.clip;

			sound.source.volume = sound.volume;
			sound.source.pitch = sound.pitch;
			sound.source.outputAudioMixerGroup = audioMixer;
			sound.source.playOnAwake = false;
		}
	}

	public void Play(bool isSpace)
	{
		if (isSpace)
		{
			sounds[sounds.Length - 1].source.Play();
		}
		else
		{
			int randN = Random.Range(0,sounds.Length - 2);	
			sounds[randN].source.Play();
		}
	}
}
