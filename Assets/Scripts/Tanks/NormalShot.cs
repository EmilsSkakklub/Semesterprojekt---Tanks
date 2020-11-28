using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalShot : MonoBehaviour
{
    public AudioSource normalShot;
    private float pitchValue = 1.0f;
    private float low = 0.75f;
    private float high = 1.25f;
    // Start is called before the first frame update
    void Start()
    {
        pitchValue = Random.Range(low, high);
        normalShot.Play();
        normalShot.pitch = pitchValue;
    }
}
