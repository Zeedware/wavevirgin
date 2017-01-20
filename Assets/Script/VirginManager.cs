using UnityEngine;
using System.Collections;

public class VirginManager : MonoBehaviour {

	public VirginController[] virginController;
	public int virginCounter;



	public int GetVirginCounter() {
		return ++virginCounter;
	}
}
