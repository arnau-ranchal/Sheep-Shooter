using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Upgrades : MonoBehaviour
{
    public TextMeshProUGUI txt; // points remaining indicator

    private int inShootRate = Upgrades_params.getinShootRate(); //0 to 5
    public List<GameObject> shootBar;

    private int inSheepRate = Upgrades_params.getinSheepRate(); //0 to 5
    public List<GameObject> sheepBar;

    private int inMovSpeed = Upgrades_params.getinMovSpeed(); //0 to 5
    public List<GameObject> movBar;

    private static int totPoints = 50; // change avaliable points here for debug purposes

    public void goBack()
    {
        SceneManager.LoadScene(0);
        Upgrades_params.setinShootRate(inShootRate); // exports for next creation of Upgrades.
    }

    public void Start()
    {
        txt.text = "Points:" + totPoints.ToString();
        Debug.Log("inShootRate:" + inShootRate);
        // setting the bar status as left in the session before
        for (int i = 4; i >= inShootRate; i--) 
        {
            shootBar[i].SetActive(false);
        }
        for (int i = 4; i >= inSheepRate; i--)
        {
            sheepBar[i].SetActive(false);
        }
        for (int i = 4; i >= inMovSpeed; i--)
        {
            movBar[i].SetActive(false);
        }
    }
        
    public static void addPoint()
    {
        totPoints++;
    }

    public void shoot()
    {
        Debug.Log("Trying to upgrade 1");
        if(inShootRate < 5 && totPoints >= 5) // if the stat is not already maxed and the player has points to buy it
        {
            Debug.Log("Upgrade 1");
            shootBar[inShootRate].SetActive(true);
            inShootRate++;
            HayMachine.shootTime(0.1F); // makes us shoot faster
            totPoints -= 5;
            txt.text = "Points: " + totPoints.ToString();
            
        }
    }

    public void sheep()
    {
        Debug.Log("Trying to upgrade 2");
        if (inSheepRate < 5 && totPoints >= 5) // if the stat is not already maxed and the player has points to buy it
        {
            Debug.Log("Upgrade 2");
            sheepBar[inShootRate].SetActive(true);
            inShootRate++;
            //HayMachine.shootTime(0.1F); // makes us shoot faster
            totPoints -= 5;
            txt.text = "Points: " + totPoints.ToString();

        }
    }

    public void mov()
    {
        Debug.Log("Trying to upgrade 3");
        if (inMovSpeed < 5 && totPoints >= 5) // if the stat is not already maxed and the player has points to buy it
        {
            Debug.Log("Upgrade 3");
            movBar[inMovSpeed].SetActive(true);
            inShootRate++;
            //HayMachine.shootTime(0.1F); // makes us shoot faster
            totPoints -= 5;
            txt.text = "Points: " + totPoints.ToString();

        }
    }
}
