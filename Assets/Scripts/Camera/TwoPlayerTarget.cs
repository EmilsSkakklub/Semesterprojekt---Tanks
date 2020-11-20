using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class TwoPlayerTarget : MonoBehaviour{

    public List<Transform> targets;

    public Vector3 offset;
    public float smoothTime = .5f;

    public float minZoom = 40f;
    public float maxZoom = 10f;
    public float zoomLimiter = 50f;
    public float fixedZoomLimiter = 0.1f;

    private Vector3 velocity;
    private Camera cam;

    public float minX = -2f;
    public float maxX = 2f;
    public float minY = -2f;
    public float maxY = 2f;

    public bool bothPlayersAlive = true;
    public PlayerHitPoints php;
    public Transform body;
    public PlayerHitPoints2 php2;
    public Transform body2;

    public Transform GlobalCoordPlayer1;
    public Transform GlobalCoordPlayer2;

    public float distance;
    public float maxDistance = 12;
    public float differenceX = 2;

    void Start()
    {
        cam = GetComponent<Camera>();
        
    }

    private void Update() {
        if (php2.PlayerHp == 0) {
            targets.Remove(body2);
            bothPlayersAlive = false;
        }
        if (php.PlayerHp == 0) {
            targets.Remove(body);
            bothPlayersAlive = false;
        }
    }
    void LateUpdate()
    {
        if (targets.Count == 0)
            return;

        Move();
        Zoom();
        StopAtBoundaries();

    }

    void Zoom()
    {
        float newZoom = Mathf.Lerp(maxZoom, minZoom, GetGreatestDistance() / zoomLimiter);
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, newZoom, Time.deltaTime);


        distance = Vector3.Distance(GlobalCoordPlayer1.position, GlobalCoordPlayer2.position); //Finds the distance between the players


        if (Mathf.Abs(GlobalCoordPlayer1.position.x) - Mathf.Abs(GlobalCoordPlayer2.position.x) <= differenceX && distance >= maxDistance || //if the distance between the players is long enough and theyre above each other, zoom out.
            Mathf.Abs(GlobalCoordPlayer2.position.x) - Mathf.Abs(GlobalCoordPlayer1.position.x) <= differenceX && distance >= maxDistance) 
            {
            zoomLimiter = 0.1f;
        } else {
            zoomLimiter = 12f; //if not, be normal
        }
    }

    void Move()
    {
        Vector3 centerPoint = GetCenterPoint();

        Vector3 newPosition = centerPoint + offset;

        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
    }

    float GetGreatestDistance()
    {
        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }

        return bounds.size.x;
    }
    Vector3 GetCenterPoint()
    {
        if (targets.Count == 1)
        {
            return targets[0].position;
        }

        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }

        return bounds.center;

    }
    void StopAtBoundaries() {
        if (bothPlayersAlive) {
            // X axis
            if (transform.position.x <= minX) {
                transform.position = new Vector3(minX, transform.position.y, offset.z);
            } else if (transform.position.x >= maxX) {
                transform.position = new Vector3(maxX, transform.position.y, offset.z);
            }

            // Y axis
            if (transform.position.y <= minY) {
                transform.position = new Vector3(transform.position.x, minY, offset.z);
            } else if (transform.position.y >= maxY) {
                transform.position = new Vector3(transform.position.x, maxY, offset.z);
            }
        } else {
            smoothTime = smoothTime * 0.99f;
        }
        
    }
}
