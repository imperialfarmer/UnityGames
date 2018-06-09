using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour {

    [SerializeField] string upgradeCode;
    [SerializeField] string originalName;
    [SerializeField] int price;
    [SerializeField] string info;

    private Button button;
    private Image image;
    private Text text;

    private bool premiseSatisfied = true;

	void Start () {
        button = GetComponent<Button>();
        image = GetComponent<Image>();
        text = transform.GetChild(0).GetComponent<Text>();
	}
	
	void Update () {

        if(upgradeCode == "upgrade_1_"){
            if(!PlayerPrefsManager.CheckUpgrade("upgrade_0_")){
                premiseSatisfied = false;
            }
        }
        if (upgradeCode == "upgrade_3_")
        {
            if (!PlayerPrefsManager.CheckUpgrade("upgrade_2_"))
            {
                premiseSatisfied = false;
            }
        }

        if(PlayerPrefsManager.CheckUpgrade(upgradeCode)){
            image.color = new Color(63f / 255f, 241f / 255f, 133f / 255f);
            text.text = info;
            text.fontSize = 20;
            text.color = Color.white;
            button.enabled = false;
        }else{
            text.text = originalName;
            text.fontSize = 30;
            if(PlayerPrefsManager.GiveMaterial() >= price && premiseSatisfied){
                image.color = new Color(250f / 255f, 81f / 255f, 81f / 255f);
                text.color = Color.white;
                button.enabled = true;
            }else{
                image.color = Color.gray;
                text.color = Color.black;
                button.enabled = false;
            }
        }
	}
}
