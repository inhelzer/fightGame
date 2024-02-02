using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    int hitCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if(other.gameObject.tag == "Player")
        {
            if ((other.GetComponentInParent<PlayerMove>().isKik) || (other.GetComponentInParent<PlayerMove>().isPunch))
            {
                hitCount++;
                if(hitCount == 1)
                {
                    GetComponent<SpriteRenderer>().color = Color.blue;
                }
                if (hitCount == 2)
                {
                    GetComponent<SpriteRenderer>().color = Color.red;
                }
                if (hitCount == 3)
                {
                    GetComponent<SpriteRenderer>().color = Color.black;
                }
                if (hitCount >=4)
                {
                    Destroy(gameObject);
                }


            }
        }
        
        
        
    }
}
