using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] protected float ReloadSceneDelay = 1;
    [SerializeField] protected ParticleSystem crashEffect;
    [SerializeField] protected AudioClip crashSFX;
    [SerializeField] protected AudioClip ouchSFX;

    CircleCollider2D playerHead;

    private bool hasCrashed = false;

    protected void Start()
    {
        playerHead = GetComponent<CircleCollider2D>();
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")
            && playerHead.IsTouching(collision.collider)
            && !hasCrashed)
        {
            PlayCrashSound();
            crashEffect.Play();
            hasCrashed = true;
            FindFirstObjectByType<PlayerController>().DisableControls();
            collision.gameObject.GetComponent<SurfaceEffector2D>().enabled = false;
            Invoke(nameof(ReloadScene), ReloadSceneDelay);
        }
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }

    private void PlayCrashSound()
    {
        GetComponent<AudioSource>().PlayOneShot(ouchSFX);
        GetComponent<AudioSource>().PlayOneShot(crashSFX);
    }
}
