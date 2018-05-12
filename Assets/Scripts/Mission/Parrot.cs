using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parrot : MonoBehaviour {
	public GameObject[] CorrectBridObj;
	public GameObject[] InputBridObj;
	public GameObject[] HintBridObj;
	public GameObject[] BridStepCorrect;
	public AudioClip Correct, Worng;

	private int currentAnswer = 0;
	private bool canClick = false;

	public void InputClick(int i) {
		if (canClick) {
			if (currentAnswer == i) {
				AudioSource.PlayClipAtPoint(Correct, gameObject.transform.position);
				CorrectBridObj[i].SetActive(true);
				InputBridObj[i].SetActive(false);
				HintBridObj[i].SetActive(false);
				currentAnswer++;
				if (currentAnswer == 3) {
					gameObject.SendMessage("ClearMission",7);
				}
			} else {
				AudioSource.PlayClipAtPoint(Worng, gameObject.transform.position);
				HintBridObj[currentAnswer].SetActive(true);
			}
		}
	}
	public void FinishStory() {
		StartCoroutine(Question());
	}
	IEnumerator Question() {
		for (int i = 0; i < BridStepCorrect.Length; i++) {
			BridStepCorrect[i].SetActive(true);
			yield return new WaitForSeconds(1f);
			BridStepCorrect[i].SetActive(false);
		}
		canClick = true;
	}
}
