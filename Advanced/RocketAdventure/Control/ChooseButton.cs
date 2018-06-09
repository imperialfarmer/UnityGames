using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseButton : MonoBehaviour {

    [SerializeField] int level;

    private Button button;
    private Image image;
    private Text text;

	void Start () {
        button = GetComponent<Button>();
        image = GetComponent<Image>();
        text = transform.GetChild(0).GetComponent<Text>();
        text.text = (level).ToString();
        if(level-1 < PlayerPrefsManager.GetUnlockLevel()){
            image.color = new Color(63f/255f,241f/255f,133f/255f);
            text.color = Color.white;
            button.enabled = true;
            button.onClick.AddListener(ClickTask);
        }
        if (level-1 == PlayerPrefsManager.GetUnlockLevel())
        {
            image.color = new Color(250f / 255f, 81f / 255f, 81f / 255f);
            text.color = Color.white;
            button.enabled = true;
            button.onClick.AddListener(ClickTask);
        }
        if (level-1 > PlayerPrefsManager.GetUnlockLevel())
        {
            image.color = Color.gray;
            text.color = Color.black;
            button.enabled = false;
        }
	}


    private void ClickTask(){
        FindObjectOfType<LevelManager>().LoadLever("Level" + (level-1).ToString());
        Rocket.GoTo(level + 2);
    }
}
