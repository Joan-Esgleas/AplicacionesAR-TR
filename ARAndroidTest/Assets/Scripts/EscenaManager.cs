using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscenaManager : MonoBehaviour
{
    public void Refresh()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
