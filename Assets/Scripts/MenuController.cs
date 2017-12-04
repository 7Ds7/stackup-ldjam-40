using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
	public void LScene(int ind) {
		SceneManager.LoadScene (ind);
    }


}