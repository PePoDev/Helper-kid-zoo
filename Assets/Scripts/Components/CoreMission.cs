using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CoreMission : MonoBehaviour {
	// Variable initial
	public GameObject Panel;
	[Header("Tutorials Settings")]
	public GameObject PanelTutorials;
	public GameObject closeTutorials;
	public Sprite[] spriteTutorials;
	public AudioClip[] VoiceTutorials;
	[Header("Ready Settings")]
	public GameObject PanelReady;
	public Sprite[] spriteReady;
	public AudioClip[] VoiceReady;

	// On start scene will call OnLoadTutorials for display tutorials
	private void Start() => StartCoroutine(OnLoadTutorials());

	// Back to scene map
	public void backToMap() => SceneManager.LoadScene(Singleton.Scene.Map.ToString());

	// When clear mission this method will do
	public void ClearMission(int Mission) {
		// Set this mission status to complate
		PlayerPrefs.SetString("MissionLevel" + Mission.ToString(), "complate");
		// Unlock next level
		PlayerPrefs.SetString("MissionLevel" + (Mission + 1).ToString(), "play");
		// Load map scene
		backToMap();
	}

	// For hide tutorials and display ready text
	public void closeTutorial() {
		PanelTutorials.SetActive(false);
		StartCoroutine(OnLoadReady());
	}

	// Method for delay to display tutorials in array spriteTutorials[]
	IEnumerator OnLoadTutorials() {
		for (int i = 0; i < spriteTutorials.Length;i++) {
			PanelTutorials.GetComponent<Image>().sprite = spriteTutorials[i];
			AudioSource.PlayClipAtPoint(VoiceTutorials[i], new Vector3(0f, 0f, 0f));
			yield return new WaitForSeconds(VoiceTutorials[i].length);
		}
		closeTutorials.SetActive(true);
	}

	// Method for delay to display ready text in array spriteReady[]
	IEnumerator OnLoadReady() {
		PanelReady.SetActive(true);
		for (int i = 0; i < spriteReady.Length; i++) {
			PanelReady.GetComponent<Image>().sprite = spriteReady[i];
			AudioSource.PlayClipAtPoint(VoiceReady[i],new Vector3(0f,0f,0f));
			yield return new WaitForSeconds(VoiceReady[i].length + 2f);
		}
		PanelReady.SetActive(false);
		Panel.SetActive(false);
	}
}