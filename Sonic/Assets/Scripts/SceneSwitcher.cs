using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneSwitcher : MonoBehaviour
{
    public bool isStart;
    // Start is called before the first frame update
    void Start()
    {
        this.isStart = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            // Forzar reinicio
            Debug.Log("Reinicio manual...");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SceneManager.LoadScene("MainScene");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SceneManager.LoadScene("Level2");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SceneManager.LoadScene("Level3");
        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            SceneManager.LoadScene("GameOver");
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            SceneManager.LoadScene("StartScreen");
        }
        else if (Input.GetKeyDown(KeyCode.N))
        {
            SceneManager.LoadScene("FinishedGame");
        } else if (Input.anyKey && this.isStart)
        {
            SceneManager.LoadScene("MainScene");
        }
    }
}

