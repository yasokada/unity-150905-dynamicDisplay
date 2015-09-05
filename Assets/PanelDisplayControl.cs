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

	public void ToggleValueChanged(int idx_st1) {
		bool isOn = getIsOn (idx_st1);

		Debug.Log (isOn.ToString ());
	}

}
