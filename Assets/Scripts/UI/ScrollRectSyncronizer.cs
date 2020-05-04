using UnityEngine;
using UnityEngine.UI;

public class ScrollRectSyncronizer : MonoBehaviour
{
	public RectTransform rectTransform;
	public RectTransform scrollRect;
	public Scrollbar scrollbar;
	public bool isVertical;
	public float offset;
	public RectTransform scrollRectContent;

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
					this.defaultAnchoredPosition.y + scrollRectContent.anchoredPosition.y);
		}
		else
		{
			this.rectTransform.anchoredPosition =
				new Vector3(
					this.defaultAnchoredPosition.x + scrollRectContent.anchoredPosition.x,
					this.rectTransform.anchoredPosition.y);
		}
	}
}
