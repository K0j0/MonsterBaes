using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HelperFunctions : MonoBehaviour {
	private static MonoBehaviour instance;

	void Awake(){
		instance = this;
	}
	public delegate void Callback();
	static IEnumerator DelayCallbackCoroutine(float delay, Callback callback){
		yield return new WaitForSeconds(delay);
		callback();
	}
	
	public static void DelayCallback(float delay, Callback callback){
		instance.StartCoroutine(DelayCallbackCoroutine(delay, callback));
	}

}