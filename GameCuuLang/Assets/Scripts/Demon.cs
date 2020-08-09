using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demon : MonoBehaviour
{
    private int blood = 200;
    private int speed = 50;
    private int damage = 20;

    public bool isRunning = false;
    public bool isAttaking = false;
    public bool isJumping = false;
    public bool isDied = false;


    public void setBlood(int blood)
    {
        this.blood = blood;
    }

    public void setSpeed(int speed)
    {
        this.speed = speed;
    }

    public void setDamage(int damage)
    {
        this.damage = damage;
    }

    public int getBlood()
    {
        return this.blood;
    }

    public int getSpeed()
    {
        return this.speed;
    }

    public int getDamage()
    {
        return this.damage;
    }

    public void Damage(int damage)
    {
        this.damage -= damage;
    }

    public void Death()
    { 
        Destroy(gameObject);
    }

    private void Update()
    {
        if (isDied) Death();
    }

}
