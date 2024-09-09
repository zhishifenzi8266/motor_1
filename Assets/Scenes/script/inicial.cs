using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.SceneManagement;

public class inicial : MonoBehaviour
{   
    public void Play()
    {
        SceneManager.LoadScene(1);
    }
    public void Quit()
    {
        Debug.Log("我退出了游戏！！！");
        Application.Quit();
    }
}
