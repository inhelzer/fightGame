using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour, Controls.IGameControlsActions
{
    [SerializeField] GameObject body;
    Controls controls;
    [SerializeField] float moveSpeed = 1;
    float direction = 0;

    Animator anim;
    string currentAnimaton;
    const string idle = "idle";
    const string kik = "kik";
    const string walk = "walk";
    const string punch = "punch";

    public bool isKik = false;
    public bool isPunch = false;
    float delay;

    private void Awake()
    {
        controls = new Controls();
        controls.GameControls.SetCallbacks(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        controls.GameControls.Enable();
        anim = body.GetComponent<Animator>();
    }

    

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveSpeed * direction * Time.deltaTime, 0, 0);
    }

    public void OnHorizontal(InputAction.CallbackContext context)
    {
        if(!context.performed)
        {
            direction = 0;
            ChangeAnimationState(idle);
        }
        if(context.performed)
        {
            direction = context.ReadValue<float>();
            if(direction > 0)
            {
                body.transform.localRotation = Quaternion.Euler(0, 85, 0);
                ChangeAnimationState(walk);
            }

            if(direction < 0)
            {
                body.transform.localRotation = Quaternion.Euler(0, -85, 0);
                ChangeAnimationState(walk);
            }
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnKik(InputAction.CallbackContext context)
    {
        if((context.performed) && (!isKik))
        {
            direction = 0;
            isKik = true;
            ChangeAnimationState(kik);
            
            Invoke("endAttack", 1.1f);
        } 
    }

    public void OnPunch(InputAction.CallbackContext context)
    {
        if ((context.performed) && (!isPunch))
        {
            direction = 0;
            isPunch = true;
            ChangeAnimationState(punch);
            Invoke("endAttack", 1f);
        }
    }

    void endAttack()
    {
        isKik = false;
        isPunch = false;
        if(direction == 0)
        {
            ChangeAnimationState(idle);
        }
        if(direction != 0 )
        {
            ChangeAnimationState(walk);
        }
        
    }

    void ChangeAnimationState(string newAnimation)
    {
        if (currentAnimaton == newAnimation) return;

        anim.Play(newAnimation);
        
        currentAnimaton = newAnimation;
    }

    private void OnDestroy()
    {
        controls.GameControls.Disable();
    }


}
