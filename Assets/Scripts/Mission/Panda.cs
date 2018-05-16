using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Panda : MonoBehaviour {
	// Initial variable
	public GameObject InputPanel;
	public GameObject MainPanel;
	public GameObject StoryPanel;
	public GameObject[] LetterObj;
	public GameObject[] RedFrame;
	public GameObject[] CorrectAnswer;
	public GameObject Quiz;
	public GameObject[] Choice;
	public Sprite Quiz2;
	public Sprite[] Choice2;
	public Sprite[] LetterImg;
	public Sprite Story2;
	public AudioClip CorrectAudio, WrongAudio, Story2Audio;

	private bool WaitInput = true;
	private int quizNumber = 1;

	public void FinishStory() {
		InputPanel.SetActive(true);
		MainPanel.GetComponent<Image>().color = new Color(0f, 0f, 0f, 0.5f);
	}
	public void OnClickInput(int choice) {
		if (WaitInput && quizNumber == 1) {
			switch (choice) {
				case 1:
				case 2:
					AudioSource.PlayClipAtPoint(WrongAudio, new Vector3(0f, 0f, -10f),0.4f);
					RedFrame[0].SetActive(true);
					break;
				case 3:
					LetterObj[0].GetComponent<Image>().sprite = LetterImg[0];
					RedFrame[0].SetActive(false);
					CorrectAnswer[0].SetActive(true);
					AudioSource.PlayClipAtPoint(CorrectAudio, new Vector3(0f, 0f, -10f),0.2f);
					quizNumber++;
					WaitInput = false;
					StartCoroutine(StoryForQuiz2());
					break;
			}
		} else if (WaitInput && quizNumber == 2) {
			switch (choice) {
				case 1:
					LetterObj[1].GetComponent<Image>().sprite = LetterImg[1];
					AudioSource.PlayClipAtPoint(CorrectAudio, new Vector3(0f, 0f, -10f),0.2f);
					RedFrame[1].SetActive(false);
					CorrectAnswer[1].SetActive(true);
					WaitInput = false;
					StartCoroutine(WinStory());
					break;
				case 2:
				case 3:
					AudioSource.PlayClipAtPoint(WrongAudio, new Vector3(0f, 0f, -10f),0.4f);
					RedFrame[1].SetActive(true);
					break;
			}
		}
	}

	IEnumerator StoryForQuiz2() {
		yield return new WaitForSeconds(1f);
		CorrectAnswer[0].SetActive(false);
		InputPanel.SetActive(false);
		MainPanel.SetActive(false);
		yield return new WaitForSeconds(1.5f);
		StoryPanel.SetActive(true);
		StoryPanel.GetComponent<Image>().sprite = Story2;
		AudioSource.PlayClipAtPoint(Story2Audio, new Vector3(0f, 0f, -10f));
		InputPanel.SetActive(false);
		MainPanel.GetComponent<Image>().color = new Color(0f, 0f, 0f, 0f);
		MainPanel.SetActive(true);
		Quiz.GetComponent<Image>().sprite = Quiz2;
		Choice[0].GetComponent<Image>().sprite = Choice2[0];
		Choice[1].GetComponent<Image>().sprite = Choice2[1];
		Choice[2].GetComponent<Image>().sprite = Choice2[2];
		yield return new WaitForSeconds(Story2Audio.length);
		StoryPanel.SetActive(false);
		InputPanel.SetActive(true);
		MainPanel.GetComponent<Image>().color = new Color(0f, 0f, 0f, 0.5f);
		MainPanel.SetActive(false);
		WaitInput = true;
	}
	IEnumerator WinStory() {
		yield return new WaitForSeconds(0.75f);
		InputPanel.SetActive(false);
		MainPanel.SetActive(false);
		yield return new WaitForSeconds(1f);
		MainPanel.SetActive(true);
		MainPanel.GetComponent<Image>().color = new Color(0f, 0f, 0f, 0f);
		gameObject.SendMessage("Win");
	}
}
