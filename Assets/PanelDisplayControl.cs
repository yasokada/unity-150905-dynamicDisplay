using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PanelDisplayControl : MonoBehaviour {

	public GameObject PageSelect;

	bool getIsOn(int idx_st1) {
		Toggle selected = null;
		string name;
		foreach (Transform child in PageSelect.transform) {
			name = child.gameObject.name;
			if (name.Contains(idx_st1.ToString())) { // e.g. "SelP1", "SelP2"...
				selected = child.gameObject.GetComponent(typeof(Toggle)) as Toggle;
				break;
			}
		}
		return selected.isOn;
	}

	void DisplayPanel(int idx_st1, bool doShow)
	{
		GameObject panel = GameObject.Find ("Panel" + idx_st1.ToString ());
		if (panel == null) {
			return;
		}

		RectTransform rect = panel.GetComponent (typeof(RectTransform)) as RectTransform;
		Vector2 size = rect.sizeDelta;
		if (doShow) {
			// TODO: how to get original size (x,y)
			size.x = 50;
			size.y = 50;
		} else {
			size.x = 1;
			size.y = 1;
		}
		rect.sizeDelta = size;
	}

	public void ToggleValueChanged(int idx_st1) {
		bool isOn = getIsOn (idx_st1);
		DisplayPanel (idx_st1, isOn);
		Debug.Log (isOn.ToString ());
	}

}
