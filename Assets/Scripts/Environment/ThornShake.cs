using UnityEngine;

public class ThornShake : MonoBehaviour
{
    
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetTrigger("shake");
        }
    }
}
