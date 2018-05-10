using UnityEngine;
using UnityEngine.UI;
public class Giraff : MonoBehaviour {
	public GameObject leg, tail;
	public GameObject legHint, tailHint;
	public AudioClip AudioWrong, AudioCorrect;

	private bool legClick = false;
	private bool tailClick = false;

	public void InputClickTail() {
		if (!tailClick) {
			AudioSource.PlayClipAtPoint(AudioCorrect, new Vector3(0f, 0f, -10f));
			tail.GetComponent<Image>().color = new Color(1, 1, 1, 1);
			tailClick = true;
			tailHint.SetActive(false);
		}
		WinCondition();
	}
	public void InputClickLeg() {
		if (!legClick) {
			AudioSource.PlayClipAtPoint(AudioCorrect, new Vector3(0f, 0f, -10f));
			leg.GetComponent<Image>().color = new Color(1, 1, 1, 1);
			legClick = true;
			legHint.SetActive(false);
		}
		WinCondition();
	}
	public void WrongClick() {
		AudioSource.PlayClipAtPoint(AudioWrong, new Vector3(0f, 0f, -10f));
		if (!legClick) {
			legHint.SetActive(true);
		} else {
			tailHint.SetActive(true);
		}
	}
	public void FinishStory() {

	}

	private void WinCondition() {
		if (legClick && tailClick) {
			gameObject.SendMessage("Win");
		}
	}
}
