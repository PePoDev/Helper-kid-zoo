using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour {
	// Obj link with tutorials in Menu scene
	public  GameObject tutorial;
	public AudioClip ClickAudio;

	// Initial all mission level
	private void Start() {
		PlayerPrefs.DeleteAll();
		PlayerPrefs.SetString("MissionLevel0", "play");
		PlayerPrefs.SetString("MissionLevel1", "lock");
		PlayerPrefs.SetString("MissionLevel2", "lock");
		PlayerPrefs.SetString("MissionLevel3", "lock");
		PlayerPrefs.SetString("MissionLevel4", "lock");
		PlayerPrefs.SetString("MissionLevel5", "lock");
		PlayerPrefs.SetString("MissionLevel6", "lock");
		PlayerPrefs.SetString("MissionLevel7", "lock");
	}

	// On click play button in menu scene
	public void PlayGame() {
		AudioSource.PlayClipAtPoint(ClickAudio, new Vector3(0f, 0f, -10f));
		SceneManager.LoadSceneAsync(Singleton.Scene.StartStory.ToString());
	}

	// On click tutorials in menu scene
	public void OpenTutorial() {
		AudioSource.PlayClipAtPoint(ClickAudio, new Vector3(0f, 0f, -10f));
		tutorial.SetActive(true);
	}

	// On click close button in menu scene
	public void CloseTutorial() {
		AudioSource.PlayClipAtPoint(ClickAudio, new Vector3(0f, 0f, -10f));
		tutorial.SetActive(false);
	}
}
