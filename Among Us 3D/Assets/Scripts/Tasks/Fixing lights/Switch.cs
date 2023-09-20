using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Switch : MonoBehaviour, IPointerClickHandler
{
    public GameObject up;
    public GameObject on;
    public bool isOn;
    public bool isUp;

    void Start()
    {
        on.SetActive(isOn);
        up.SetActive(isUp);

        if (isOn)
        {
            Main.instance.SwithchChange(1);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        isOn = !isOn;
        isUp = !isUp;
        on.SetActive(isOn);
        up.SetActive(isUp);

        if (isOn)
        {
            Main.instance.SwithchChange(1);
        }
        else
        {
            Main.instance.SwithchChange(-1);
        }
    }
}
