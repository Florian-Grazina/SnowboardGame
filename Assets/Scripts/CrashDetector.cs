using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] protected float ReloadSceneDelay = 1;
    [SerializeField] protected ParticleSystem crashEffect;
    [SerializeField] protected AudioClip crashSFX;
    [SerializeField] protected AudioClip ouchSFX;

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
            PlayCrashSound();
            crashEffect.Play();
            FindFirstObjectByType<PlayerController>().DisableControls();
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
