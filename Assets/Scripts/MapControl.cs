using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MapControl : MonoBehaviour {
	//
	public GameObject[] Mission;
	public Sprite[] MissionPlay,MissionComplate;
	public AudioClip buttonClick;

	// 
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
	public void PlayMission(int mission) {
		if (levelState[mission].Equals("play")) {
			AudioSource.PlayClipAtPoint(buttonClick,Vector3.zero);
			SceneManager.LoadScene(Singleton.Scene.Mission.ToString() + mission.ToString());
		}
	}
}
