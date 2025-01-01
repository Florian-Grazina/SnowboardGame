using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] protected float reloadSceneDelay = 2;
    [SerializeField] protected ParticleSystem finishEffect;

    private bool isFinished;

    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !isFinished)
        {
            isFinished = true;
            finishEffect.Play();
            GetComponent<AudioSource>().Play();
            Invoke(nameof(ReloadScene), reloadSceneDelay);
        }
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
