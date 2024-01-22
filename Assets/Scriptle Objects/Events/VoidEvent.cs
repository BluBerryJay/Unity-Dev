using UnityEngine;
using UnityEngine.Events;
[CreateAssetMenu(menuName = "Events/Event")]
public class VoidEvent : MonoBehaviour
{
	public UnityAction<int> onEventRaised;
	public void RaiseEvent(int value)
	{
		onEventRaised?.Invoke(value);
	}
	public void Subscribe(UnityAction<int> function)
	{
		onEventRaised += function;
	}
	public void UnSubscribe(UnityAction<int> function)
	{
		onEventRaised -= function;
	}
}
