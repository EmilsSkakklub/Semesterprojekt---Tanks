using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class ExplosionRadius : MonoBehaviour
{
    public GameObject explosion;
    private Vector3 scaleChange;

    private int explosionRadius = 15;
    private float explosionSpeed = 30f;


    // Update is called once per frame
    void Update()
    {
        scaleChange = new Vector3(explosionSpeed * Time.deltaTime, explosionSpeed * Time.deltaTime, 0f);
        explosion.transform.localScale += scaleChange;


        if (explosion.transform.localScale.x >= explosionRadius)
        {
            Destroy(gameObject);
        }
    }
}
