using UnityEngine;
using UnityEngine.UI;

public class Panda : MonoBehaviour {
	// Initial variable
	public GameObject InputPanel;
	public GameObject[] LetterObj;
	public GameObject[] RedFrame;
	public GameObject[] CorrectAnswer;
	public Sprite[] LetterImg;
	public AudioClip CorrectAudio, WrongAudio;

	private int quizNumber = 1;

	public void FinishStory() {
		InputPanel.SetActive(true);
	}
	public void OnClickInput(int choice) {
		switch (quizNumber) {
			case 1:
				switch (choice) {
					case 1:
					case 2:
						AudioSource.PlayClipAtPoint(WrongAudio, new Vector3(0f, 0f, -10f));
						RedFrame[0].SetActive(true);
						break;
					case 3:
						RedFrame[0].SetActive(false );
						AudioSource.PlayClipAtPoint(CorrectAudio, new Vector3(0f, 0f, -10f));
						quizNumber++;
						break;
				}
				break;
			case 2:
				switch (choice) {
					case 1:
						AudioSource.PlayClipAtPoint(CorrectAudio, new Vector3(0f, 0f, -10f));
						break;
					case 2:
					case 3:
						AudioSource.PlayClipAtPoint(WrongAudio, new Vector3(0f, 0f, -10f));
						break;
				}
				break;
		}
	}
}
