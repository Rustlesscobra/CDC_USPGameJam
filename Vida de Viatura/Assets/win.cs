using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class win : MonoBehaviour
{
    public Animator transition;
    public float transitionTime;

    private void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(LoadLevel(3));
        }
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}
