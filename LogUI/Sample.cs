using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LogUI;

public class Sample : MonoBehaviour
{
	private IEnumerator Start()
	{
		for (;;)
		{
			yield return new WaitForSeconds(1f);

			Debug.Log("Sample Message - Message");
			Debug.LogWarning("Sample Message - Warning");
			Debug.LogAssertion("Sample Message - Assertion");
			Debug.LogError("Sample Message - Error");
		}
	}
}