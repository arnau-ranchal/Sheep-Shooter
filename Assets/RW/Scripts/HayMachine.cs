using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class HayMachine : MonoBehaviour
{
    public static float movementSpeed = 14;
    public static float maxMovementSpeed = 27;

    public float horizontalBoundary = 22;

    public GameObject hayBalePrefab; // 1
    public Transform haySpawnpoint; // 2
    private static float shootInterval = 0.9F; // 3
    private static float minShootInterval = 0.3F;
    private float shootTimer; // 4

    private void Start()
    {
        Debug.Log("ms is:" + movementSpeed);
    }
    // Update is called once per frame
    private void Update()
    {
        UpdateMovement();
        UpdateShooting();
    }

    private void UpdateMovement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal"); // 1

        if (horizontalInput < 0 && transform.position.x > -horizontalBoundary) // 1
        {
            transform.Translate(transform.right * -movementSpeed * Time.deltaTime);
        }
        else if (horizontalInput > 0 && transform.position.x < horizontalBoundary) // 2
        {
            transform.Translate(transform.right * movementSpeed * Time.deltaTime);
        }
    }

    private void UpdateShooting()
    {
        shootTimer -= Time.deltaTime;

        if (shootTimer <= 0 && Input.GetKey(KeyCode.Space))
        {
            shootTimer = shootInterval;
            ShootHay();
        }
    }

    private void ShootHay()
    {
        Instantiate(hayBalePrefab, haySpawnpoint.position, Quaternion.identity);
    }

    public static void shootTime(double mytime)
    {
        shootInterval = (float) System.Math.Max(minShootInterval,shootInterval - mytime);
        Debug.Log("New shoot interval: " + shootInterval);
    }

    public static void movementSpeedPlayer(double mytime)
    {
       movementSpeed = (float)System.Math.Min(maxMovementSpeed, movementSpeed + mytime);
        Debug.Log("New player speed: " + movementSpeed);
    }
}