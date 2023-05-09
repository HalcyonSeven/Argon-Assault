using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private float loadDelay = 1.5f;
    // [SerializeField] AudioClip crashSound;
    // [SerializeField] AudioClip successSound;
    // [SerializeField] ParticleSystem crashParticle;
    // [SerializeField] ParticleSystem successParticle;


    private AudioSource audioSource;

    bool isGameTransitioning;

    private void Start()
    {
        isGameTransitioning = false;
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {

        if (isGameTransitioning) { return; }
        switch (other.gameObject.tag)
        {
            case "Finish":
                TransitionToNextLevel();
                break;
            default:
                StartCrashSequence();
                break;
        }
    }
    void StartCrashSequence()
    {
        isGameTransitioning = true;
        audioSource.Stop();
        // audioSource.PlayOneShot(crashSound);
        // crashParticle.Play();
        GetComponent<PlayerController>().enabled = false;
        StartCoroutine(ReloadScene());
    }
    void TransitionToNextLevel()
    {
        isGameTransitioning = true;
        audioSource.Stop();
        // audioSource.PlayOneShot(successSound);
        // successParticle.Play();
        GetComponent<PlayerController>().enabled = false;
        StartCoroutine(LoadNextLevel());
    }
    IEnumerator ReloadScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        yield return new WaitForSeconds(loadDelay);
        SceneManager.LoadScene(currentSceneIndex);
        GetComponent<PlayerController>().enabled = true;
    }
    IEnumerator LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        yield return new WaitForSeconds(loadDelay);
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
        GetComponent<PlayerController>().enabled = true;
    }
}