using UnityEngine;
using UnityEngine.UI;

public class SpeedSlider : MonoBehaviour {

    public Text text;

    private string originalText;

	public void UpdateText(float speed) {
        text.text = originalText + ": " + speed.ToString("0.00");
	}

    void Start() {
        originalText = text.text;
    }
}
