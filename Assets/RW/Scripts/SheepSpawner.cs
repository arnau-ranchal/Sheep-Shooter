using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SheepSpawner : MonoBehaviour
{
    public bool canSpawn = true;
    public GameObject sheepPrefab;
    //public GameObject ghostSheepPrefab;
    public List<Transform> sheepSpawnPositions = new List<Transform>();
    private static float timeBetweenSpawns = 2;
    private static float minTimeBetweenSpawns = 0.8F;
    private List<GameObject> sheepList = new List<GameObject>();

    public TextMeshProUGUI txt;
    private int points;

    public int pointstowin;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine (SpawnRoutine());
        points = 0;
    }

    private void SpawnSheep()
    {
        Vector3 randomPosition = sheepSpawnPositions[Random.Range(0, sheepSpawnPositions.Count)].position; // 1

        GameObject sheep;
        //if (Random.Range(1, 10) == 1) // 10% prob
        //{
        //    sheep = Instantiate(ghostSheepPrefab, randomPosition, ghostSheepPrefab.transform.rotation); // 2
        //}
        //else
        //{
            sheep = Instantiate(sheepPrefab, randomPosition, sheepPrefab.transform.rotation); // 2
        //}
        sheepList.Add(sheep); // 3
        sheep.GetComponent<Sheep>().SetSpawner(this); // 4

    }

     private IEnumerator SpawnRoutine() // 1
     {
      while (canSpawn) // 2
      {
        SpawnSheep(); // 3
        yield return new WaitForSeconds(timeBetweenSpawns); // 4
      }
     }

     public void RemoveSheepFromList (GameObject sheep)
     {
        sheepList.Remove(sheep);
     }

    private void setText(int x) => txt.text = "Count: " + x.ToString();

    public void addPoint()
    {
        points++;
        setText(points);

        Upgrades.addPoint(); // updates the TOTAL number of points between games. they are not deleted.

        if (points >= pointstowin)
        {
            SceneManager.LoadScene(0);
        }
    }

    public static void spawnTime(double mytime)
    {
        timeBetweenSpawns = (float)System.Math.Max(minTimeBetweenSpawns, timeBetweenSpawns - mytime);
        Debug.Log("New time: " + timeBetweenSpawns);
    }

}
