using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class life : MonoBehaviour
{
    [SerializeField] GameObject body;

    [SerializeField] int maxLife = 3;
    [SerializeField] GameObject lifeText;
    int currentLife;

    const string idle = "idle";
    const string stunned = "stunned";
    const string headHit = "headHit";
    Animator anim;
    string currentAnimaton;

    // Start is called before the first frame update
    void Start()
    {
        currentLife = maxLife;
        anim = body.GetComponent<Animator>();

        
    }

    // Update is called once per frame
    void Update()
    {
        lifeText.GetComponent<Text>().text = currentLife.ToString();

        
    }

    public void LooseLife()
    {
        currentLife--;
        ChackEndLife();
    }

    public void ChackEndLife()
    {
        if (currentLife <= 0)
        {
            ChangeAnimationState(stunned);
        }
        else
        {
            ChangeAnimationState(headHit);
            Invoke("EndHitAnim", 1.13f);
        }
    }
    
    void ChangeAnimationState(string newAnimation)
    {
        if (currentAnimaton == newAnimation) return;

        anim.Play(newAnimation);

        currentAnimaton = newAnimation;
    }

    void EndHitAnim()
    {
        ChangeAnimationState(idle);
    }
    
}
