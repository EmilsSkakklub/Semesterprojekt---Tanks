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

    /*
    public float xPlayer1min = 2f;
    public float xPlayer1max = 2f;
    public float yPlayer1min = 2f;
    public float yPlayer1max = 2f;
    public float xPlayer2min = 2f;
    public float xPlayer2max = 2f;
    public float yPlayer2min = 2f;
    public float yPlayer2max = 2f;
    */

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

        if (bothPlayersAlive) {
            StopAtBoundaries();
        } else {
            smoothTime = smoothTime*0.99f;
        }
        
    }

    void Zoom()
    {
        float newZoom = Mathf.Lerp(maxZoom, minZoom, GetGreatestDistance() / zoomLimiter);
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, newZoom, Time.deltaTime);
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

        /*if (targets[0].position.x > xPlayer1min && targets[0].position.x < xPlayer1max && 
            targets[0].position.y > yPlayer1min && targets[0].position.y < yPlayer1max && 

            targets[1].position.x > xPlayer2min && targets[1].position.x < xPlayer2max &&
            targets[1].position.x > yPlayer2min && targets[1].position.x < yPlayer2max) {

            zoomLimiter = fixedZoomLimiter;
        } else {
            zoomLimiter = 11f;
        }*/
    }
}
