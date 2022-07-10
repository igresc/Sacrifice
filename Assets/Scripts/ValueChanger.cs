using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ValueChanger : MonoBehaviour
{
	public TextMeshProUGUI bunnyText;
	public TextMeshProUGUI birdoText;
	public TextMeshProUGUI mushiText;
	// Start is called before the first frame update
	void Start()
	{
		bunnyText.SetText(SacrificialCounter.bunniesSacrified.ToString());
		birdoText.SetText(SacrificialCounter.birdosSacrified.ToString());
		mushiText.SetText(SacrificialCounter.mushisSacrified.ToString());
	}
}
