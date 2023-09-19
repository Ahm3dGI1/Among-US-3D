using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;

    public Animator anim;

    public float speed = 12f;

    // Update is called once per frame
    void Update()
    {

        if (!GetComponent<Interactor>().isTasking)
        {
            float x = Input.GetAxisRaw("Horizontal");
            float z = Input.GetAxisRaw("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;

            controller.Move(move * speed * Time.deltaTime);

            if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            {
                anim.SetTrigger("motion");
            }
            else
            {
                anim.ResetTrigger("motion");
            }
        }

    }
}
