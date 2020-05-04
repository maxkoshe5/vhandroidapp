using UnityEngine;
using UnityEngine.UI;

public class ScrollRectSyncronizer : MonoBehaviour
{
	public RectTransform rectTransform;
	public RectTransform scrollRect;
	public Scrollbar scrollbar;
	public bool isVertical;
	public float offset;

	public Vector2 defaultAnchoredPosition;

	private void Awake()
	{
		this.defaultAnchoredPosition = this.rectTransform.anchoredPosition;
	}

	private void Update()
	{
		if (this.isVertical)
		{
			this.rectTransform.anchoredPosition =
				new Vector3(
					this.rectTransform.anchoredPosition.x,
					this.defaultAnchoredPosition.y + (1 - this.scrollbar.value) * (this.scrollRect.sizeDelta.y - this.offset));
		}
		else
		{
			this.rectTransform.anchoredPosition =
				new Vector3(
					this.defaultAnchoredPosition.x - (this.scrollbar.value) * (this.scrollRect.sizeDelta.x - this.offset),
					this.rectTransform.anchoredPosition.y);
		}
	}
}
