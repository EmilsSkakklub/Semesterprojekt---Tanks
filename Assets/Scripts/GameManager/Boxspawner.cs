using UnityEngine;
using System.Collections.Generic;

public class Boxspawner : MonoBehaviour {
    public List<Transform> spawnPointsTransform;
    public GameObject box;
    public Transform pool;

    public int BoxCount = 0;
    public int BoxMax = 2;

    private float counter = 0f;
    public float BoxResetTime = 5f;

    private int lastSpawnPointIndex = -1;

    public Transform spawn1;
    public Transform spawn2;
    public Transform spawn3;
    public Transform spawn4;
    public Transform spawn5;
    public Transform spawn6;

    public sp1 sp1;
    public sp2 sp2;
    public sp3 sp3;
    public sp4 sp4;
    public sp5 sp5;
    public sp6 sp6;


    public bool stopRemoving1 = true;
    public bool stopAdding1 = true;

    public bool stopRemoving2 = true;
    public bool stopAdding2 = true;

    public bool stopRemoving3 = true;
    public bool stopAdding3 = true;

    public bool stopRemoving4 = true;
    public bool stopAdding4 = true;

    public bool stopRemoving5 = true;
    public bool stopAdding5 = true;

    public bool stopRemoving6 = true;
    public bool stopAdding6 = true;


    private void Start() {                                  // Starts with max amount of boxes
        while (BoxCount < BoxMax) {
            SpawnBox();
        }
        

    }
    void Update() {                                         // Spawns box' till the max is reached
        if (BoxCount < BoxMax) {
            if (counter < BoxResetTime) {
                counter += Time.deltaTime;
            } else {
                counter = 0;
                SpawnBox();
            }
        }
        //----------------------------------------------------------------
        if (!sp1.SpawnAvaliable1 && !stopRemoving1) {                  //1
            stopRemoving1 = true;
            spawnPointsTransform.Remove(spawn1);
        }
        if (sp1.SpawnAvaliable1 && !stopAdding1) {
            stopAdding1 = true;
            spawnPointsTransform.Add(spawn1);
        }
        //----------------------------------------------------------------
        if (!sp2.SpawnAvaliable2 && !stopRemoving2) {                  //2
            stopRemoving2 = true;
            spawnPointsTransform.Remove(spawn2);
        }
        if (sp2.SpawnAvaliable2 && !stopAdding2) {
            stopAdding2 = true;
            spawnPointsTransform.Add(spawn2);
        }
        //----------------------------------------------------------------
        if (!sp3.SpawnAvaliable3 && !stopRemoving3) {                  //3
            stopRemoving3 = true;
            spawnPointsTransform.Remove(spawn3);
        }
        if (sp3.SpawnAvaliable3 && !stopAdding3) {
            stopAdding3 = true;
            spawnPointsTransform.Add(spawn3);
        }
        //----------------------------------------------------------------
        if (!sp4.SpawnAvaliable4 && !stopRemoving4) {                  //4
            stopRemoving4 = true;
            spawnPointsTransform.Remove(spawn4);
        }
        if (sp4.SpawnAvaliable4 && !stopAdding4) {
            stopAdding4 = true;
            spawnPointsTransform.Add(spawn4);
        }
        //----------------------------------------------------------------
        if (!sp5.SpawnAvaliable5 && !stopRemoving5) {                  //5
            stopRemoving5 = true;
            spawnPointsTransform.Remove(spawn5);
        }
        if (sp5.SpawnAvaliable5 && !stopAdding5) {
            stopAdding5 = true;
            spawnPointsTransform.Add(spawn5);
        }
        //----------------------------------------------------------------
        if (!sp6.SpawnAvaliable6 && !stopRemoving6) {                  //6
            stopRemoving6 = true;
            spawnPointsTransform.Remove(spawn6);
        }
        if (sp6.SpawnAvaliable6 && !stopAdding6) {
            stopAdding6 = true;
            spawnPointsTransform.Add(spawn6);
        }
        //-----------------------------------------------------------------
    }
        public void SpawnBox() {                                                     // Spawns a box                                   
        BoxCount++; 
        Transform spawnPoint = GetNextSpawnPoint();
        GameObject prefab = box;
        Instantiate(prefab, spawnPoint.position, Quaternion.identity, pool);
    }
    private Transform GetNextSpawnPoint() {                                         //Prevents spawning on the same position as previous spawn                             
        int index = (lastSpawnPointIndex + Random.Range(1, spawnPointsTransform.Count - 1)) % spawnPointsTransform.Count;
        lastSpawnPointIndex = index;
        return spawnPointsTransform[index];
    }
} 