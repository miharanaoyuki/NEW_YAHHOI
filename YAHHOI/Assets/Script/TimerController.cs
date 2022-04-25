using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
	public Text timerText;

	public static float totalTime;
	int seconds;
	public static bool doikun = false;
	public static float time = 0;

	void Start()
	{

	}

	void Update()
	{
        if (doikun)
        {
			totalTime += Time.deltaTime;
			seconds = (int)totalTime;
        }
        else if(Shot.fly)
        {
			time += Time.deltaTime;
        }
		timerText.text = seconds.ToString();
	}
}
