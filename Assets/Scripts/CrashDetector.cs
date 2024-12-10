using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField]
    protected float ReloadSceneDelay = 1;
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
            Invoke(nameof(ReloadScene), 1);
            Debug.Log("Crash!");
        }
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(ReloadSceneDelay);
    }
}
