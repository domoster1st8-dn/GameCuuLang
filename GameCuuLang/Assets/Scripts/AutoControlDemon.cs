using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoControlDemon : MonoBehaviour
{
    public GameObject demon;
    private bool isDemonDied;
    private float spawnTime; // thời gian tái tạo demon
    private bool isGameover;



    private void Start()
    {
        createDemon();
        spawnTime = 0;
        isDemonDied = false;
    }

    private void Update()
    {
        if (isGameover) return;
        if (isDemonDied)
        { // nếu demon đã chết
            spawnTime -= Time.deltaTime; // đếm thời gian để chuẩn bị hồi sinh demon
            if (spawnTime <= 0)
            { // hết thời gian đợi
                createDemon(); // hồi sinh demon
                spawnTime = Random.Range(2, 5); // Tạo lại thời gian đợi
            }
        }
    }

    // Tạo demon mới
    public void createDemon()
    {
        Vector2 demonPosition = new Vector2(Random.Range(-10, 50), Random.Range(1, 3));
        if (demon)
        {
            Instantiate(demon, demonPosition, Quaternion.identity); // tạo ra 1 demon ở vị trí demonPosition
            Debug.Log("Demon da duoc tao ra");
            this.isDemonDied = false; // demon còn sống
        }
    }

    // return true nếu demon đã chết
    public bool IsDemonDied()
    {
        return this.isDemonDied;
    }

    public void SetDemonDied(bool state)
    {
        this.isDemonDied = state;
    }

    public bool IsGameOver()
    {
        return this.isGameover;
    }

    public void SetGameOverState(bool state)
    {
        this.isGameover = state;
    }

    
}
