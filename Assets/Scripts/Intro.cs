using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    public void LoadGame()
    {
		SceneManager.LoadScene (1);
    }


}