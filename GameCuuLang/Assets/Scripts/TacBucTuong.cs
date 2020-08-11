using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TacBucTuong : MonoBehaviour
{
    public GameObject BucTuong;
    
   

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("VienDa"))
        {
            Destroy(gameObject);
            Destroy(BucTuong.gameObject);
        }
    }
}
