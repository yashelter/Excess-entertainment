using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelProgress : MonoBehaviour
{
	public Slider slider;
	public Gradient gradient;
	public Image fill;
	public Stats stats;

	public void SetOurProgress(int xp)
	{
		slider.maxValue = xp;

		fill.color = gradient.Evaluate(1f);
	}

	public void SetProgress(int xp)
	{
		slider.value = xp;
		Debug.Log(xp);
		fill.color = gradient.Evaluate(slider.normalizedValue);
	}
}
