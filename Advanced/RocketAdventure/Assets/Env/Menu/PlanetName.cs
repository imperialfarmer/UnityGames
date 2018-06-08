using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetName : MonoBehaviour {

    [SerializeField] int level;

    private Image image;
	void Start () {
        image = GetComponent<Image>();
        if (level <= PlayerPrefsManager.GetUnlockLevel())
        {
            image.color = new Color(63f / 255f, 241f / 255f, 133f / 255f);
        }
        if (level > PlayerPrefsManager.GetUnlockLevel())
        {
            image.color = new Color(250f / 255f, 81f / 255f, 81f / 255f);
        }
	}
	
}
