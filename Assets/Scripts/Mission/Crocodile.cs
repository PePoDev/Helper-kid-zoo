using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Crocodile : MonoBehaviour {
	[Header("Setting")]

	// Group crocodille
	public GameObject[] CrocodilleGroup;

	// MainPanel and LosePanel for show lose panel
	public GameObject MainPanel, LosePanel;

	// Audio voice Correct, Wrong
	public AudioClip CorrectAudio, WrongAudio;

	// Audio voice lose
	public AudioClip VoiceLose;

	// Count user lose for hint
	private bool Reseted = false;

	// Crocodilles correct number
	private int NumCrocodillesCorrect = 0;

	[Header("Crocodille Group 1")]
	// For show red circle when click right crocodille group 1
	public GameObject[] RedCircle1;
	
	[Header("Crocodille Group 2")]

	// For show red circle when click right crocodille group 2
	public GameObject[] RedCircle2;

	// Link with correct crocodille for hint player
	public GameObject[] HintCorrectCrocodilles;

	// Sprite for normal Crocodilles
	public Sprite[] normalCrocodilles;

	// Sprite for red Crocodilles
	public Sprite[] redCrocodilles;
	
	// For detect answer when click crocodille
	public void OnClickCrocodilles(int id) {
		switch (id) {
			case 1:
				if (!Reseted) {
					AudioSource.PlayClipAtPoint(WrongAudio, new Vector3(0f, 0f, -10f));
					GameReset();
				} else {
					AudioSource.PlayClipAtPoint(CorrectAudio, new Vector3(0f, 0f, -10f));
					HintCorrectCrocodilles[0].SetActive(false);
					RedCircle2[0].SetActive(true);
					NumCrocodillesCorrect++;
				}
				break;
			case 2:
				if (!Reseted) {
					AudioSource.PlayClipAtPoint(WrongAudio, new Vector3(0f, 0f, -10f));
					GameReset();
				} else {
					AudioSource.PlayClipAtPoint(WrongAudio, new Vector3(0f, 0f, -10f));
					if (RedCircle2[0].activeSelf)
						HintCorrectCrocodilles[1].SetActive(true);
					else
						HintCorrectCrocodilles[0].SetActive(true);
				}
				break;
			case 3:
				if (!Reseted) {
					AudioSource.PlayClipAtPoint(CorrectAudio, new Vector3(0f, 0f, -10f));
					RedCircle1[0].SetActive(true);
					NumCrocodillesCorrect++;
				} else {
					AudioSource.PlayClipAtPoint(CorrectAudio, new Vector3(0f, 0f, -10f));
					HintCorrectCrocodilles[1].SetActive(false);
					RedCircle2[1].SetActive(true);
					NumCrocodillesCorrect++;
				}
				break;
			case 4:
				if (!Reseted) {
					AudioSource.PlayClipAtPoint(CorrectAudio, new Vector3(0f, 0f, -10f));
					RedCircle1[1].SetActive(true);
					NumCrocodillesCorrect++;
				} else {
					AudioSource.PlayClipAtPoint(WrongAudio, new Vector3(0f, 0f, -10f));
					if (RedCircle2[0].activeSelf)
						HintCorrectCrocodilles[1].SetActive(true);
					else
						HintCorrectCrocodilles[0].SetActive(true);
				}
				break;
		}
		if (NumCrocodillesCorrect == 2) {
			gameObject.SendMessage("Win");
		}
	}

	// Reset when wrong click
	public void GameReset() {
		StartCoroutine(DisplayLosePanel());
		Reseted = true;
		NumCrocodillesCorrect = 0;
		RedCircle1[0].SetActive(true);
		RedCircle1[1].SetActive(true);
		CrocodilleGroup[0].SetActive(false);
		CrocodilleGroup[1].SetActive(true);
	}

	public void FinishStory() {

	}

	// Delay for display lose panel
	IEnumerator DisplayLosePanel() {
		MainPanel.SetActive(true);
		LosePanel.SetActive(true);
		AudioSource.PlayClipAtPoint(VoiceLose,new Vector3(0f,0f,-10f));
		yield return new WaitForSeconds(VoiceLose.length + 1.5f);
		MainPanel.SetActive(false);
		LosePanel.SetActive(false);
	}
}
