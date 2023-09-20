using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Main : MonoBehaviour
{
    static public Main instance;
    public int switchCount;
    private int switchesOn;
    public bool taskDone = false;

    private void Awake()
    {
        instance = this;

        taskDone = false;
    }

    public void SwithchChange(int points)
    {
        switchesOn += points;

        if (switchesOn == switchCount)
        {
            taskDone = true;
        }
    }
}
