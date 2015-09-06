using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/*
 * v0.3 2015/09/06
 *   - use Tag for Panel to find target panels, instead of panel name
 * v0.2 2015/09/06
 *   - add sample UI components in each panel
 * v0.1 2015/09/05
 *   - show/hide panels
 */

public class PanelDisplayControl : MonoBehaviour {

	public GameObject PageSelect;
	public GameObject PanelGroup;

	private Vector2[] orgSize;

	void Start() {
		orgSize = new Vector2[4];
		int idx=0;

		foreach (Transform child in PanelGroup.transform) {
			orgSize[idx].x = child.gameObject.GetComponent<RectTransform>().rect.width;
			orgSize[idx].y = child.gameObject.GetComponent<RectTransform>().rect.height;

			bool isOn = getIsOn (idx + 1);
			DisplayPanel (idx + 1, isOn);

			idx++;
		}

	}

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
		GameObject [] panels = GameObject.FindGameObjectsWithTag ("TagP" + idx_st1.ToString ());

		if (panels == null) {
			return;
		}

		foreach (GameObject panel in panels) {
			RectTransform rect = panel.GetComponent (typeof(RectTransform)) as RectTransform;
			Vector2 size = rect.sizeDelta;
			if (doShow) {
				size.x = orgSize [idx_st1 - 1].x;
				size.y = orgSize [idx_st1 - 1].y;
			} else {
				size.x = 0;
				size.y = 0;
			}
			rect.sizeDelta = size;
		}
	}

	public void ToggleValueChanged(int idx_st1) {
		bool isOn = getIsOn (idx_st1);
		DisplayPanel (idx_st1, isOn);
		Debug.Log (isOn.ToString ());
	}

}
