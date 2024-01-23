using UnityEngine;
using UnityEngine.Events;

public class VoidEventListener : MonoBehaviour
{
	[SerializeField] private VoidEvent _event = default;

	public UnityEvent listener;
	private void OnEnable()
	{
		//_event?.Subscribe(Respond);
	}

	private void OnDisable()
	{
		//_event?.UnSubscribe(Respond);
	}

	private void Respond()
	{
		listener?.Invoke();
	}
}
