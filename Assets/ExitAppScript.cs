using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitAppScript : MonoBehaviour
{
    public void ExitApplication()
    {
        Debug.Log("ApplicationQuitCalled");
        Application.Quit();
    }
}
