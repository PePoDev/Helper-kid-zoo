using System.Collections;
using UnityEngine;

public class Monkey : MonoBehaviour {
	public GameObject mainPanel, playPanel;
	public GameObject MonkeyObj;
	public Sprite MonkeyEatBanana;
	public GameObject[] InputStep;
	public GameObject[] HintStep;
	public GameObject[] AnswerStep;
	public GameObject WinObj;
	public AudioClip WinAudio, CorrectAudio, WrongAudio;

	private int currentStep = 0;

	public void ClickInput(int i) {
		if (currentStep == i) {
			AudioSource.PlayClipAtPoint(CorrectAudio, new Vector3(0f, 0f, -10f));
			HintStep[currentStep].SetActive(false);
			InputStep[i].SetActive(false);
			AnswerStep[i].SetActive(true);
			currentStep++;
		} else {
			AudioSource.PlayClipAtPoint(WrongAudio, new Vector3(0f, 0f, -10f));
			HintStep[currentStep].SetActive(true);
		}
		if (currentStep == 3) {
			StartCoroutine(WinMonkey());
			currentStep++;
		}
	}
	public void FinishStory() {
		StartCoroutine(WaitToDisplayPlayPanel());
	}
	IEnumerator WaitToDisplayPlayPanel() {
		yield return new WaitForSeconds(1.5f);
		mainPanel.SetActive(true);
		playPanel.SetActive(true);
	}
	IEnumerator WinMonkey() {
		WinObj.SetActive(true);
		AudioSource.PlayClipAtPoint(WinAudio, new Vector3(0f, 0f, -10f));
		yield return new WaitForSeconds(1.5f);
		mainPanel.SetActive(false);
		playPanel.SetActive(false);
		gameObject.SendMessage("Win");
	}
}
