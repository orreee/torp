using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class IntroScript : MonoBehaviour
{
    [SerializeField]
    Sprite[] images;
    [SerializeField]
    Image image;
    [SerializeField]
    GameObject foregroundObject;
    Queue<Sprite> queue;
    bool done = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        queue = new();
        foreach(Sprite image in images)
        {
            queue.Enqueue(image);
        }
        Handle();
    }
    
    void Handle()
    {
        if(queue.Count == 0)
        {
            Destroy(image.gameObject);
            done = true;
            Leave();
            return;
        }
        image.sprite = queue.Dequeue();
        Fade();
    }

    public void EndOfAnimation()
    {
        Handle();
    }

    public void LeaveAnimation()
    {
        if (done)
        {
            Destroy(gameObject);
        }
    }

    void Fade()
    {
        foregroundObject.GetComponent<Animator>().SetTrigger("Start");
    }
    void Leave()
    {
        foregroundObject.GetComponent<Animator>().SetTrigger("Leave");
    }
}
