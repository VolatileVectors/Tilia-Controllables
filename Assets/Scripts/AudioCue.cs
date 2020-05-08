using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AudioCue", menuName = "Audio Cue", order = 100)]
public class AudioCue : ScriptableObject
{
    public List<AudioClip> audioClips = new List<AudioClip>();
    [Range(0f, 1f)] public float volume = 1f;
    [Range(0f, 1f)] public float volumeVariation;
    [Range(0f, 5f)] public float pitch = 1f;
    [Range(0f, 5f)] public float pitchVariation;
    public float minDelay = 0.1f;

    private float _lastPlayTime;

    public void Play(AudioSource source)
    {
        if (_lastPlayTime + minDelay <= Time.realtimeSinceStartup && audioClips.Count > 0)
        {
            _lastPlayTime = Time.realtimeSinceStartup;
            if (source.isPlaying)
            {
                source.Stop();
            }

            source.volume = Mathf.Clamp01(volumeVariation == 0f ? volume : Random.Range(volume - volumeVariation, volume + volumeVariation));
            source.pitch = Mathf.Clamp(pitchVariation == 0f ? pitch : Random.Range(pitch - pitchVariation, pitch + pitchVariation), 0f, 5f);
            source.clip = audioClips[Random.Range(0, audioClips.Count - 1)];
            source.Play();
        }
    }
}