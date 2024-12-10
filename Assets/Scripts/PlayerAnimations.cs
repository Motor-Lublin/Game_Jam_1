using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] Animator animator;
    public static PlayerAnimations Instance;

    private void Awake()
    {
        Instance = this;
        animator = GetComponent<Animator>();
    }

    public void Run()
    {
        animator.SetBool("IsRunning", true);
    }

    public void Idle()
    {
        animator.SetBool("IsRunning", false);
    }
}
