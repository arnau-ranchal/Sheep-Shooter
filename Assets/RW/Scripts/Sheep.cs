using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class Sheep : MonoBehaviour
{
    public float runSpeed;
    public float gotHayDestroyDelay;
    private bool hitByHay;

    public float dropDestroyDelay;
    private Collider myCollider;
    private Rigidbody myRigidbody;

    public SheepSpawner sheepSpawner;



    // Start is called before the first frame update
    private void Start()
    {
        myCollider = GetComponent<Collider>();
        myRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(Vector3.forward * runSpeed * Time.deltaTime);
    }

    private void HitByHay() 
    {
        hitByHay = true; 
        runSpeed = 0;

        Destroy(gameObject, gotHayDestroyDelay);
        sheepSpawner.RemoveSheepFromList(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hay") && !hitByHay)
        {
            Destroy(other.gameObject);
            HitByHay();
            sheepSpawner.addPoint();
            HayMachine.shootTime(0.1);
            SheepSpawner.spawnTime(0.3);
            HayMachine.movementSpeedPlayer(1);
        }
        else if (other.CompareTag("DropSheep"))
        { 
            Drop(other);
        }
    }

    private void Drop(Collider other)
    {
        myCollider.isTrigger = false;
        myRigidbody.isKinematic = false;
        Destroy(gameObject, dropDestroyDelay);
        sheepSpawner.RemoveSheepFromList(gameObject);
        
    }

    public void SetSpawner(SheepSpawner spawner)
    {
        sheepSpawner = spawner;
    }
}