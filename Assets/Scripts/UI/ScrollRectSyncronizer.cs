using UnityEngine;
using UnityEngine.UI;

public class ScrollRectSyncronizer : MonoBehaviour
{
	public RectTransform rectTransform;
	public RectTransform scrollRect;
	public Scrollbar scrollbar;

	private void Update()
	{
		this.rectTransform.anchoredPosition = 
			new Vector3(
				this.rectTransform.position.x,
				(1 - this.scrollbar.value) * this.scrollRect.sizeDelta.y,
				this.rectTransform.position.z);
	}
}
