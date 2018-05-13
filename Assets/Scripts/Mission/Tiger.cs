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
				gameObject.SendMessage("Win");
			} else {
				AudioSource.PlayClipAtPoint(Wrong, gameObject.transform.position);
				HintChoice.SetActive(true);
			}
	}
	public void FinishStory() {
		StartCoroutine(Question());
	}
	IEnumerator Question() {
		AS.volume = 0f;
		PlayPanel.SetActive(true);
		AudioSource.PlayClipAtPoint(QestionVoice, gameObject.transform.position);
		yield return new WaitForSeconds(QestionVoice.length);
		canClick = true;
		AS.volume = 1f;
		SoundIcon.GetComponent<Image>().sprite = SoundIconSprite;
	}
}
