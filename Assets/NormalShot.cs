using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalShot : MonoBehaviour
{
    public AudioSource normalShot;
    // Start is called before the first frame update
    void Start()
    {
        normalShot.Play();
    }
}
