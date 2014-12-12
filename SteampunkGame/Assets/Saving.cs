using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class Saving {
	public static List<SavedBehaviour> savedScripts = new List<SavedBehaviour>();
	public static void ListSavedFields() {
		System.Attribute attr = System.Attribute.GetCustomAttribute(typeof(TestSavedScript),typeof(SavedAttribute));
		Debug.Log (attr.ToString());

	}
}

public class SavedBehaviour : MonoBehaviour {
	public SavedBehaviour() {

	}
}

[System.AttributeUsage(System.AttributeTargets.Field)]
public class SavedAttribute : System.Attribute {
	public SavedAttribute() {
		Debug.Log("test");
	}
}