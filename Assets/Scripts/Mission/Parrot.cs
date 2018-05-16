using System.Collections;
using UnityEngine;

public class Parrot : MonoBehaviour {
	public GameObject[] CorrectBridObj;
	public GameObject[] InputBridObj;
	public GameObject[] HintBridObj;
	public GameObject[] BridStepCorrect;
	public AudioClip Correct, Worng, QuestionVoice;

	private int currentAnswer = 1;

	public void InputClick(int i) {
		if (currentAnswer == i) {
			AudioSource.PlayClipAtPoint(Correct, gameObject.transform.position,0.2f);
			CorrectBridObj[i - 1].SetActive(true);
			InputBridObj[i - 1].SetActive(false);
			HintBridObj[i - 1].SetActive(false);
			currentAnswer++;
			if (currentAnswer == 4) {
				gameObject.SendMessage("ClearMission", 7);
			}
		} else {
			AudioSource.PlayClipAtPoint(Worng, gameObject.transform.position,0.4f);
			HintBridObj[currentAnswer - 1].SetActive(true);
		}
	}
	public void FinishStory() {
		StartCoroutine(Question());
	}
	IEnumerator Question() {
		AudioSource.PlayClipAtPoint(QuestionVoice, gameObject.transform.position);
		yield return new WaitForSeconds(6.5f);

		BridStepCorrect[0].SetActive(true);
		yield return new WaitForSeconds(4f);
		BridStepCorrect[0].SetActive(false);

		BridStepCorrect[1].SetActive(true);
		yield return new WaitForSeconds(3.5f);
		BridStepCorrect[1].SetActive(false);

		BridStepCorrect[2].SetActive(true);
		yield return new WaitForSeconds(3f);
		BridStepCorrect[2].SetActive(false);

		gameObject.SendMessage("TurnOnCanDrag");
	}
}
