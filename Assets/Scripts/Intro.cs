using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    public void NextLevelButton(int index)
    {
        SceneManager.LoadScene(index);
    }


}