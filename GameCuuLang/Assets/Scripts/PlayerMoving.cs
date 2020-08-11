using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    public CharacterController2D controller2D;
    float horizontalmove = 0f;
    public float runspeed = 40f;
    bool jump = false;

    void Update()
    {
        horizontalmove = Input.GetAxisRaw("Horizontal") * runspeed;
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }
    private void FixedUpdate()
    {
        controller2D.Move(horizontalmove * Time.fixedDeltaTime , false, jump);
        jump = false;
    }
}
