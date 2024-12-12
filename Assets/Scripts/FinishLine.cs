using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField]
    protected float reloadSceneDelay = 1;
    [SerializeField]
    protected ParticleSystem finishEffect;

    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            finishEffect.Play();
            Invoke(nameof(ReloadScene), reloadSceneDelay);
        }
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
