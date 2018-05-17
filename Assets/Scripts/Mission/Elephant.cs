using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Elephant : MonoBehaviour {
	public GameObject[] AnimalObj;
	public GameObject Hint;
	public AudioClip WrongClick;
	public AudioClip RightClick;
	public Sprite[] AnimalSprite;
	public AudioClip[] AnimalVoice;
	public AudioClip QuestionVoice;
	public AudioSource AS;

	private bool canClick = false;

	public void InputClick(int i) {
		if (canClick)
			switch (i) {
				case 0:
					AudioSource.PlayClipAtPoint(RightClick, gameObject.transform.position,0.2f);
					gameObject.SendMessage("Win");
					break;
				case 1:
					AudioSource.PlayClipAtPoint(WrongClick, gameObject.transform.position,0.4f);
					Hint.SetActive(true);
					break;
				case 2:
					AudioSource.PlayClipAtPoint(WrongClick, gameObject.transform.position,0.4f);
					Hint.SetActive(true);
					break;
			}
	}
	public void FinishStory() {
		StartCoroutine(Question());
	}
	IEnumerator Question() {
		AS.volume = 0f;
		yield return new WaitForSeconds(0.5f);
		for (int i = 0; i < AnimalVoice.Length; i++) {
			AnimalObj[i].GetComponent<Image>().sprite = AnimalSprite[i * 2 + 1];
			AudioSource.PlayClipAtPoint(AnimalVoice[i], gameObject.transform.position, 0.4f);
			yield return new WaitForSeconds(AnimalVoice[i].length);
			AnimalObj[i].GetComponent<Image>().sprite = AnimalSprite[i * 2];
		}
		yield return new WaitForSeconds(0.5f);
		AudioSource.PlayClipAtPoint(QuestionVoice, gameObject.transform.position);
		yield return new WaitForSeconds(3.2f);
		AS.volume = 0.3f;
		yield return new WaitForSeconds(QuestionVoice.length - 3.2f);
		canClick = true;
	}
}
