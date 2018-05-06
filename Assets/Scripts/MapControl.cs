using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MapControl : MonoBehaviour {
	// Variable initial
	public GameObject[] Mission;
	public Sprite[] MissionPlay,MissionComplate;
	public AudioClip buttonClick;

	// For collect all mission status
	private string[] levelState;

	// Initial map scene about mission level status
	private void Start() {
		levelState = new string[8];
		for (int i = 0; i < 8; i++) {
			levelState[i] = PlayerPrefs.GetString("MissionLevel" + i.ToString());
			if (levelState[i].Equals("play")) {
				Mission[i].GetComponent<Image>().sprite = MissionPlay[i];
			} else if (levelState[i].Equals("complate")) {
				Mission[i].GetComponent<Image>().sprite = MissionComplate[i];
			}
		}
	}

	// On click mission
	public void PlayMission(int mission) {
		if (levelState[mission].Equals("play")) {
			AudioSource.PlayClipAtPoint(buttonClick,new Vector3(0f,0f,-10f));
			SceneManager.LoadSceneAsync(Singleton.Scene.Mission.ToString() + mission.ToString());
		}
	}
}
