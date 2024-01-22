using System;
using UnityEngine;
[CreateAssetMenu(menuName = "Variables/Int")]
public class IntValue : ScriptableObject, ISerializationCallbackReceiver
{
	public int initialValue;
	[NonSerialized]
	public int value;


	public void OnAfterDeserialize()
	{
		value = initialValue;
	}

	public void OnBeforeSerialize()
	{
		//
	}
}
