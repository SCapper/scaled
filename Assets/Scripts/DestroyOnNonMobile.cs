using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnNonMobile : MonoBehaviour {
	
	void Start () 
	{
		#if !UNITY_ANDRIOD && !UNITY_IPHONE && !UNITY_BLACKBERRY && !UNITY_WINRT
		Destroy(this.gameObject);
		#endif
	}
}
