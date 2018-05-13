using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Tiger : MonoBehaviour {
	public GameObject PlayPanel;
	public AudioClip QestionVoice;
	public AudioClip Wrong, Correct;
	public GameObject TigetObj;
	public Sprite TigerSprite;
	public GameObject SoundIcon;
	public Sprite SoundIconSprite;
	public GameObject HintChoice;
	public AudioSource AS;

	private bool canClick = false;

	public void InputClick(int i) {
		if (canClick)
			if (i == 0) {
				PlayPanel.SetActive(false);
				AudioSource.PlayClipAtPoint(Correct, gameObject.transform.position);
				TigetObj.GetComponent<Image>().sprite = TigerSprite;
				StartCoroutine(ShowTiger());
			} else {
				AudioSource.PlayClipAtPoint(Wrong, gameObject.transform.position);
				HintChoice.SetActive(true);
			}
	}
	public void FinishStory() {
		StartCoroutine(Question());
	}
	IEnumerator Question() {
		yield return new WaitForSeconds(1.5f);
		PlayPanel.SetActive(true);
		yield return new WaitForSeconds(0.3f);
		AudioSource.PlayClipAtPoint(QestionVoice, gameObject.transform.position);
		yield return new WaitForSeconds(6.8f);
		AS.volume = 0f;
		yield return new WaitForSeconds(12.6f - 6.8f);
		AS.volume = 0.3f;
		yield return new WaitForSeconds(QestionVoice.length - 12.6f);
		canClick = true;
		AS.volume = 0.3f;
		SoundIcon.GetComponent<Image>().sprite = SoundIconSprite;
	}
	IEnumerator ShowTiger() {
		yield return new WaitForSeconds(1.5f);
		gameObject.SendMessage("Win");
	}
}
