using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetorOnSpaceBar : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Reloads the current level
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}

