using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task_initiator : MonoBehaviour
{
    public GameObject taskUI;

    public bool fx_light = false;
    public bool fx_wiring = false;

    void Start()
    {
        taskUI.SetActive(false);
    }

    public void StartTask()
    {
        taskUI.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void EndTask()
    {
        taskUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
