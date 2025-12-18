using System.Collections;
using TMPro;
using UnityEngine;


public class Timer: MonoBehaviour
{

    [SerializeField]private TextMeshProUGUI inGameText;
    private float inGameTime;

	void Update()
	{
        inGameTime += Time.deltaTime;
        inGameText.text = FormatTime();
    }

    private string FormatTime()
    {
        int minutes = Mathf.FloorToInt(inGameTime / 60);
        int seconds = Mathf.FloorToInt(inGameTime % 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds); 
    }

}
