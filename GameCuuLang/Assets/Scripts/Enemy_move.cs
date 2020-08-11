using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemy_move : MonoBehaviour
{
    public int speed;
    public bool MoveRight;
    

    // Update is called once per frame
    void Update()
    {
        if (MoveRight)
        {
            transform.Translate(2 * speed * Time.deltaTime, 0, 0);
            transform.localScale = new Vector2(1, 1);
        }
        else
        {
            transform.Translate(- 2 * speed * Time.deltaTime, 0, 0);
            transform.localScale = new Vector2(-1, 1);
        }
    }
}
