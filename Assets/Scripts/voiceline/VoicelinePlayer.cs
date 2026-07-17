using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class VoicelinePlayer : MonoBehaviour
{
    private bool playing;
    private AudioSource source;
    private Queue<AudioClip> queue;
    private float timer = 0.0f;
    private float target_time = 0.0f;
    public bool Playing { get { return playing; } }
    public void Init(AudioSource source)
    {
        playing = false;
        this.source = source;
        queue = new Queue<AudioClip>();
    }

    #region Interface
    public void Play(AudioClip clip)
    {
        if (playing)
        {
            Queue(clip);
            return;
        }
        ManualPlay(clip);
    }
    public void Queue(AudioClip clip)
    {
        queue.Enqueue(clip);
    }
    public void Stop()
    {
        if (playing)
        {
            ManualStop();
        }
    }
    public void Skip()
    {
        if (playing)
        {
            PlayNext();
        }
    }
    #endregion

    #region Logic
    private void ManualPlay(AudioClip clip)
    {
        source.clip = clip;
        source.Play();
        SetTime(clip.length);
        playing = true;
    }
    private void ManualStop()
    {
        source.Stop();
        playing = false;
        queue.Clear();
    }
    private void PlayNext()
    {
        if (queue.Count > 0)
        {
            ManualPlay(queue.Dequeue());
            return;
        }
        ManualStop();
    }
    private void SetTime(float target_time)
    {
        this.target_time = target_time;
        timer = 0.0f;
    }
    void Update()
    {
        if (!playing)
        {
            return;
        }
        if(timer >= target_time)
        {
            PlayNext();
        }
        else
        {
            timer += Time.deltaTime;
        }
    }
    #endregion
}