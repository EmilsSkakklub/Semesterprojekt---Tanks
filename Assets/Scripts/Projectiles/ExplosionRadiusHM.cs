using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionRadiusHM : MonoBehaviour
{
    public GameObject explosion;
    private Vector3 scaleChange;

    private int explosionRadius = 8;
    private float explosionSpeed = 30f;
    private Color colorStart = Color.black;
    private Color colorEnd = Color.red;


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
