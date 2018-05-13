using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CoreMission : MonoBehaviour {
	// Variable initial
	public GameObject Panel;
	public AudioClip ClickAudio;
    
	[Header("Tutorials Settings")]
	public GameObject PanelTutorials;
	public GameObject closeTutorials;
	public Sprite[] spriteTutorials;
	public AudioClip[] VoiceTutorials;
	[Header("Ready Settings")]
	public GameObject PanelReady;
	public Sprite[] spriteReady;
	public AudioClip[] VoiceReady;
    [Header("Win Settings")]
    public AudioClip WinVoice;
	public GameObject PanelWin;
	public GameObject WinButton;

	// On start scene will call OnLoadTutorials for display tutorials
	private void Start() => StartCoroutine(OnLoadTutorials());

	// Back to scene map
	public void backToMap() {
		AudioSource.PlayClipAtPoint(ClickAudio, new Vector3(0f, 0f, -10f));
		SceneManager.LoadSceneAsync(Singleton.Scene.Map.ToString());
	}

	// When clear mission this method will do
	public void ClearMission(int Mission) {
		// Set this mission status to complate
		PlayerPrefs.SetString("MissionLevel" + Mission.ToString(), "complate");
		// If this mission is last level
		if (Mission == 7) {
			AudioSource.PlayClipAtPoint(ClickAudio, new Vector3(0f, 0f, -10f));
			SceneManager.LoadSceneAsync(Singleton.Scene.EndStory.ToString());
		} else { // If not
			// Unlock next level
			PlayerPrefs.SetString("MissionLevel" + ( Mission + 1 ).ToString(), "play");
			// Load map scene
			backToMap();
		}
	}

	// For hide tutorials and display ready text
	public void closeTutorial() {
		AudioSource.PlayClipAtPoint(ClickAudio, new Vector3(0f, 0f, -10f));
		PanelTutorials.SetActive(false);
		StartCoroutine(OnLoadReady());
	}

	// Win text display
	public void Win() {
		Panel.SetActive(true);
		PanelWin.SetActive(true);
		StartCoroutine(WinDelay());
	}

	// Method for delay to display tutorials in array spriteTutorials[]
	IEnumerator OnLoadTutorials() {
		yield return new WaitForSeconds(1f);
		for (int i = 0; i < spriteTutorials.Length;i++) {
			PanelTutorials.GetComponent<Image>().sprite = spriteTutorials[i];
			AudioSource.PlayClipAtPoint(VoiceTutorials[i], new Vector3(0f, 0f, -10f));
			yield return new WaitForSeconds(VoiceTutorials[i].length + 0.75f);
		}
		closeTutorials.SetActive(true);
	}

	// Method for delay to display ready text in array spriteReady[]
	IEnumerator OnLoadReady() {
		PanelReady.SetActive(true);
		for (int i = 0; i < spriteReady.Length; i++) {
			PanelReady.GetComponent<Image>().sprite = spriteReady[i];
			AudioSource.PlayClipAtPoint(VoiceReady[i],new Vector3(0f,0f,-10f));
			yield return new WaitForSeconds(VoiceReady[i].length + 0.75f);
		}
		PanelReady.SetActive(false);
		Panel.SetActive(false);
		gameObject.SendMessage("FinishStory");
	}
	IEnumerator WinDelay() {
		AudioSource.PlayClipAtPoint(WinVoice, gameObject.transform.position);
		yield return new WaitForSeconds(WinVoice.length);
		WinButton.SetActive(true);
	}
}