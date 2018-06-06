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
        text.text = (level + 1).ToString();
        if(level < PlayerPrefsManager.GetUnlockLevel()){
            image.color = Color.green;
            text.color = Color.white;
            button.enabled = true;
            button.onClick.AddListener(ClickTask);
        }
        if (level == PlayerPrefsManager.GetUnlockLevel())
        {
            image.color = Color.red;
            text.color = Color.white;
            button.enabled = true;
            button.onClick.AddListener(ClickTask);
        }
        if (level > PlayerPrefsManager.GetUnlockLevel())
        {
            image.color = Color.gray;
            text.color = Color.black;
            button.enabled = false;
        }
	}

    private void ClickTask(){
        FindObjectOfType<LevelManager>().LoadLever("Level" + level.ToString());
        Rocket.GoTo(level + 3);
    }
}
