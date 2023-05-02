using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrades_params : MonoBehaviour
{
    // global variables belong here, otherwise we would reset the upgrade stats everytime we created the upgrade canvas.

    // It works!!

    private static int inShootRate = 0; //0 to 5
    private static int inSheepRate = 0; //0 to 5
    private static int inMovSpeed = 0;  //0 50 5

    public static int getinShootRate()
    {
        return inShootRate;
    }

    public static void setinShootRate(int x)
    {
        inShootRate = x;
    }

    public static int getinSheepRate()
    {
        return inSheepRate;
    }

    public static void setinSheepRate(int x)
    {
        inSheepRate = x;
    }

    public static int getinMovSpeed()
    {
        return inMovSpeed;
    }

    public static void setinMovSpeed(int x)
    {
        inMovSpeed = x;
    }

}
