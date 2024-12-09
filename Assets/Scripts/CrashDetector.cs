using UnityEngine;
using UnityEngine.U2D;

public class CrashDetector : MonoBehaviour
{
    CircleCollider2D playerHead;

    protected void Start()
    {
        playerHead = GetComponent<CircleCollider2D>();
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")
            && playerHead.IsTouching(collision.collider))
        {
            collision.gameObject.GetComponent<SurfaceEffector2D>().enabled = false;
            Debug.Log("Crash!");
        }
    }
}
