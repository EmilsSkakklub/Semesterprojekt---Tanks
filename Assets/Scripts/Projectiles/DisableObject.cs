using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableObject : MonoBehaviour
{

    public destroyBullet db;

    // Update is called once per frame
    void Update()
    {
        if (db.disableObject)
        {
            gameObject.SetActive(false);
            db.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
