using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public GameObject up;
    public GameObject on;
    public bool isOn;
    public bool isUp;

    void Start()
    {
        on.SetActive(isOn);
        up.SetActive(isUp);
    }

    private void OnMouseUp()
    {
        isOn = !isOn;
        isUp = !isUp;
        on.SetActive(isOn);
        up.SetActive(isUp);
    }
}
