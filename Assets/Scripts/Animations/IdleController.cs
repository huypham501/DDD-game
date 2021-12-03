using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleController : MonoBehaviour
{
    public Animator animator;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Up"))
        {
            Debug.Log("1");
            setIsBack();
        }
        else if (Input.GetButtonDown("Down"))
        {
            Debug.Log("2");
            setIsFront();
        }
        else if (Input.GetButtonDown("Left"))
        {
            Debug.Log("3");
            setIsLeft();
        }
        else if (Input.GetButtonDown("Right"))
        {
            Debug.Log("4");
            setIsRight();
        }
    }

    private void setIsBack()
    {
        animator.SetBool("isBack", true);
        animator.SetBool("isFront", false);
        animator.SetBool("isRight", false);
        animator.SetBool("isLeft", false);
    }

    private void setIsFront()
    {
        animator.SetBool("isBack", false);
        animator.SetBool("isFront", true);
        animator.SetBool("isRight", false);
        animator.SetBool("isLeft", false);
    }

    private void setIsLeft()
    {
        animator.SetBool("isBack", false);
        animator.SetBool("isFront", false);
        animator.SetBool("isRight", false);
        animator.SetBool("isLeft", true);
    }

    private void setIsRight()
    {
        animator.SetBool("isBack", false);
        animator.SetBool("isFront", false);
        animator.SetBool("isRight", true);
        animator.SetBool("isLeft", false);
    }
}
