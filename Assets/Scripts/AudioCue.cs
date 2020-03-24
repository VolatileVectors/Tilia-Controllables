using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AudioCue", menuName = "Audio Cue", order = 100)]
public class AudioCue : ScriptableObject
{
    public List<AudioClip> AudioClips = new List<AudioClip>();
    [Range(0f, 1f)]
    public float Volume = 1f;
    [Range(0f, 1f)]
    public float VolumeVariation = 0f;
    [Range(0f, 5f)]
    public float Pitch = 1f;
    [Range(0f, 5f)]
    public float PitchVariation = 0f;
    public float MinDelay = 0.1f;

    private float lastPlayTime = 0f;

    public void Play(AudioSource source)
    {
        if (lastPlayTime + MinDelay <= Time.realtimeSinceStartup && AudioClips.Count > 0)
        {
            lastPlayTime = Time.realtimeSinceStartup;
            if (source.isPlaying)
            {
                source.Stop();
            }
            source.volume = Mathf.Clamp01(VolumeVariation == 0f ? Volume : Random.Range(Volume - VolumeVariation, Volume + VolumeVariation));
            source.pitch = Mathf.Clamp(PitchVariation == 0f ? Pitch : Random.Range(Pitch - PitchVariation, Pitch + PitchVariation), 0f, 5f);
            source.clip = AudioClips[Random.Range(0, AudioClips.Count - 1)];
            source.Play();
        }
    }
}
