using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResolutionButton : MonoBehaviour {

    [SerializeField] int resolutionCode;

    private Text text;
    private Image image;

    private void Start()
    {
        text = transform.GetChild(0).gameObject.GetComponent<Text>();
        image = GetComponent<Image>();
        text.color = Color.white;
        text.fontSize = 35;

        if (resolutionCode == 0) text.text = "5 : 4";
        if (resolutionCode == 1) text.text = "4 : 3";
        if (resolutionCode == 2) text.text = "3 : 2";
        if (resolutionCode == 3) text.text = "16 : 10";
        if (resolutionCode == 4) text.text = "16 : 9";
    }

    private void Update()
    {
        string resCode = "res_" + resolutionCode + "_";
        if(PlayerPrefsManager.CheckResolution(resCode)){
            image.color = new Color(63f / 255f, 241f / 255f, 133f / 255f);
        }else{
            image.color = new Color(250f / 255f, 81f / 255f, 81f / 255f);
        }
    }

    public void ChangeResolution(){
        string resCode = "res_" + resolutionCode + "_";
        PlayerPrefsManager.SetResolution(resCode, 1);
        for (int i = 0; i < 5; i++){
            if(i != resolutionCode){
                string otherCode = "res_" + i + "_";
                PlayerPrefsManager.SetResolution(otherCode, 0);
            }
        }
    }
}
