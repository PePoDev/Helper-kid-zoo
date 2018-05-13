using System.Collections;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class StoryControl : MonoBehaviour {
	public GameObject VideoStroy;
	public GameObject ImageTemp;
	public GameObject Go;

	private void Start() {
		StartCoroutine(WaitStoryEnd());
	}
	public void play() {
		SceneManager.LoadSceneAsync(Singleton.Scene.Map.ToString());
	}
	IEnumerator WaitStoryEnd() {
		yield return new WaitUntil(() => VideoStroy.GetComponent<VideoPlayer>().isPlaying);
		yield return new WaitForSeconds(0.2f);
		ImageTemp.SetActive(false);
		yield return new WaitUntil(() => !VideoStroy.GetComponent<VideoPlayer>().isPlaying);
		Go.SetActive(true);
	}
}
