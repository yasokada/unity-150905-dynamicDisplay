using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PanelDisplayControl : MonoBehaviour {

	public GameObject PageSelect;
	
	public void ToggleValueChanged(int idx_st1) {
		Toggle selected = null;
		string name;
		foreach (Transform child in PageSelect.transform) {
			name = child.gameObject.name;
			if (name.Contains(idx_st1.ToString())) { // e.g. "SelP1", "SelP2"...
				selected = child.gameObject.GetComponent(typeof(Toggle)) as Toggle;
				break;
			}
		}

		Debug.Log(idx_st1.ToString() + " is " + selected.isOn);
	}

}
