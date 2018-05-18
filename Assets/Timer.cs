using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {

	public float Delay = 5.0f;

	void Start ()
	{
		StartCoroutine(WaitBeforeSwitch());
	}

	IEnumerator WaitBeforeSwitch()
	{
		yield return new WaitForSeconds(Delay);

		SceneManager.LoadScene("FINAL_SCENE_BUILD");
	}
}
