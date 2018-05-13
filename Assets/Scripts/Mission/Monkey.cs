using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Monkey : MonoBehaviour {
	public GameObject mainPanel, playPanel;
	public GameObject MonkeyObj;
	public Sprite MonkeyEatBanana;
	public GameObject[] InputStep;
	public GameObject[] HintStep;
	public GameObject[] AnswerStep;
	public GameObject WinObj;
	public AudioClip WinAudio, CorrectAudio, WrongAudio;

	private int currentStep = 1;

	public void ClickInput(int i) {
		if (currentStep == i) {
			AudioSource.PlayClipAtPoint(CorrectAudio, new Vector3(0f, 0f, -10f));
			HintStep[currentStep-1].SetActive(false);
			InputStep[i-1].SetActive(false);
			AnswerStep[i-1].SetActive(true);
			currentStep++;
		} else {
			AudioSource.PlayClipAtPoint(WrongAudio, new Vector3(0f, 0f, -10f));
			HintStep[currentStep-1].SetActive(true);
		}
		if (currentStep == 4) {
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
		yield return new WaitForSeconds(WinAudio.length + 0.5f);
		mainPanel.SetActive(false);
		playPanel.SetActive(false);
		MonkeyObj.GetComponent<Image>().sprite = MonkeyEatBanana;
		yield return new WaitForSeconds(1.5f);
		gameObject.SendMessage("Win");
	}
}
