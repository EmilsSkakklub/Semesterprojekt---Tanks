using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBox : MonoBehaviour {


    public GameObject[] Pickups;
    public Boxspawner bs;
    bool OnlyOnce = false;
    bool OnlyOnce2 = false;

    public ParticleSystem ps;
    

    public void Awake() {
        bs = GameObject.Find("GameManager").GetComponent<Boxspawner>();
    }


    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Bullet" || other.gameObject.tag == "Bomb") {
            GameObject PickupSpawn = Instantiate(Pickups[Random.Range(0, Pickups.Length)], transform.position, transform.rotation) as GameObject;
            bs.BoxCount--;
            BoxDestroyAnimation();
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "LaserCollider" && !OnlyOnce)
        {
            GameObject PickupSpawn = Instantiate(Pickups[Random.Range(0, Pickups.Length)], transform.position, transform.rotation) as GameObject;
            OnlyOnce = true;
            bs.BoxCount--;
            Destroy(collision.gameObject);
            BoxDestroyAnimation();
            Destroy(gameObject);
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        if ((other.gameObject.tag == "FlameBlue" || other.gameObject.tag == "FlamePink") && !OnlyOnce2)
        {
            GameObject PickupSpawn = Instantiate(Pickups[Random.Range(0, Pickups.Length)], transform.position, transform.rotation) as GameObject;
            OnlyOnce2 = true;
            bs.BoxCount--;
            BoxDestroyAnimation();
            Destroy(gameObject);
        }
    }


    private void BoxDestroyAnimation() {
        Instantiate(ps, transform.position, Quaternion.identity);
    }

}
