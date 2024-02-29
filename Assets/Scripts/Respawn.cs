using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class respawn : MonoBehaviour {

	void FixedUpdate () {
		if (transform.position.y < -10)
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}
}