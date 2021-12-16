using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
	public static HealthBar Instance { get; private set; }
	public Image bar;
	float originalSize;

	void Awake ()
	{
		Instance = this;
	}

	void OnEnable()
	{
		originalSize = bar.rectTransform.rect.width;
	}

	public void SetValue(float value)
	{		
		bar.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSize * value);
	}
}
