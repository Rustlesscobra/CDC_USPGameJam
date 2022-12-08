using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// pelo amor de deus alguem testa essa desgrasa (n consigo)
public class GameOverScreen : MonoBehaviour
{
    // o kara no video adiciono score como parametro mas a gente n ta usando essas coisa de pontito score entao acho q n precisa
    //https://www.youtube.com/watch?v=K4uOjb5p3Io esse eo video do kara
    public void Setup()
    {
        gameObject.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene("Cozinha");
    }
}
