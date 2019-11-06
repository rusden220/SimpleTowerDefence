using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FrameRateManager : MonoBehaviour
{
	public Text FrameRateText;

	void Update()
	{
		DebugShowFrameRate();
	}

	private void DebugShowFrameRate()
	{
		var frameRate = (int)(1.0f / Time.smoothDeltaTime);
		FrameRateText.text = frameRate.ToString();
	}
}
