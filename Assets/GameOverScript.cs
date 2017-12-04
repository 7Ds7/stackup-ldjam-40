using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
	public void LoadIntro()
	{
		SceneManager.LoadScene (0);
	}


}