using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour {
	[SerializeField]
	// Obj link with tutorials in Menu scene
	private GameObject tutorial;

	// initial all mission level
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
		SceneManager.LoadScene(Singleton.Scene.Map.ToString());
	}

	// On click tutorials in menu scene
	public void OpenTutorial() {
		tutorial.SetActive(true);
	}

	// On click close button in menu scene
	public void CloseTutorial() {
		tutorial.SetActive(false);
	}
}
