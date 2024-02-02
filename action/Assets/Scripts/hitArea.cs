using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitArea : MonoBehaviour
{
    [SerializeField] float kikCoolDown = 1.1f;
    [SerializeField] float punchCoolDown = 0.9f;

    float hitTime;

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            
            if (other.GetComponentInParent<PlayerMove>().isKik)
            {
                if(Time.timeSinceLevelLoad - hitTime >= kikCoolDown)
                {
                    
                    GetComponentInParent<life>().LooseLife();
                    hitTime = Time.timeSinceLevelLoad;
                }

            }
            if (other.GetComponentInParent<PlayerMove>().isPunch)
            {
                if (Time.timeSinceLevelLoad - hitTime >= punchCoolDown)
                {
                    GetComponentInParent<life>().LooseLife();
                    hitTime = Time.timeSinceLevelLoad;
                }

            }
        }



    }
}
