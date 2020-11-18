using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;

public class destroyHM : MonoBehaviour
{

    public ParticleSystem HMparticle;
    public GameObject explosion; 


    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
            Instantiate(HMparticle, transform.position, Quaternion.identity);
            Instantiate(explosion, transform.position, Quaternion.identity);
        }
        else if(other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            Instantiate(HMparticle, transform.position, Quaternion.identity);
            Instantiate(explosion, transform.position, Quaternion.identity);
        }
        
        


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
