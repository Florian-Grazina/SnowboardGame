using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] protected float ReloadSceneDelay = 1;
    [SerializeField] protected ParticleSystem crashEffect;

    CircleCollider2D playerHead;

    private bool _hasCrashed = false;

    protected void Start()
    {
        playerHead = GetComponent<CircleCollider2D>();
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")
            && playerHead.IsTouching(collision.collider)
            && !_hasCrashed)
        {
            crashEffect.Play();
            _hasCrashed = true;
            collision.gameObject.GetComponent<SurfaceEffector2D>().enabled = false;
            Invoke(nameof(ReloadScene), ReloadSceneDelay);
        }
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
