using UnityEngine;

public class AnimationController : MonoBehaviour
{
    readonly Animator animator;
    
    public AnimationController(Animator animator)
    {
        this.animator = animator;
    }

    public bool IsWalk
    {
        get
        {
            return animator.GetBool("isWalk");
        }
        set
        {
            animator.SetBool("isWalk", value);
        }
    }

    public bool IsJump
    {
        get
        {
            return animator.GetBool("isJump");
        }
        set
        {
            animator.SetBool("isJump", value);
        }
    }

    public bool IsCrouch
    {
        get
        {
            return animator.GetBool("isCrouch");
        }
        set
        {
            animator.SetBool("isCrouch", value);
        }
    }

    public bool IsPunch
    {
        get
        {
            return animator.GetBool("isPunch");
        }
        set
        {
            animator.SetBool("isPunch", value);
        }
    }

    public bool IsKick
    {
        get
        {
            return animator.GetBool("isKick");
        }
        set
        {
            animator.SetBool("isKick", value);
        }
    }

    public bool IsUpper
    {
        get
        {
            return animator.GetBool("isUpper");
        }
        set
        {
            animator.SetBool("isUpper", value);
        }
    }

    public bool IsGard
    {
        get
        {
            return animator.GetBool("isGard");
        }
        set
        {
            animator.SetBool("isGard", value);
        }
    }

    public bool Special
    {
        get
        {
            return animator.GetBool("special");
        }
        set
        {
            animator.SetBool("special", value);
        }
    }
}
