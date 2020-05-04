using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalendarController : MonoBehaviour
{
	public GameObject calendarStripe;
	public GameObject contentStripe;
	public GameObject calendarEvent;
	public RectTransform dateStripeParent;
	public RectTransform scrollRectContent;
	public List<CalendarStripeController> instantiatedCalendarStripes;
	public List<GameObject> contentClones;
	public float timeStripeWidth = 240;
	public float timeStripeHeight = 80;

	public void CreateNextMonth(Patient patient)
	{
		ClearCalendar();

		var lastDateTime = this.instantiatedCalendarStripes.Count > 0
			? this.instantiatedCalendarStripes[this.instantiatedCalendarStripes.Count - 1].stripeDateTime.AddDays(1)
			: DateTime.Now.Date;

		for (int i = 0; i < 31; i++)
		{
			this.instantiatedCalendarStripes.Add(this.CreateCalendarStripe(lastDateTime));
			lastDateTime = lastDateTime.AddDays(1);

			var content = CreateCalendarContent();

			if (patient.LyingCondition)
			{
				for (int k = 0; k < 12; k++)
				{
					var clone = GameObject.Instantiate(this.calendarEvent.gameObject, content.transform);

					var cloneRectTransform = clone.GetComponent<RectTransform>();

					cloneRectTransform.anchoredPosition = new Vector2(cloneRectTransform.anchoredPosition.x, cloneRectTransform.anchoredPosition.y - 240 - (160 * k));

					var eventText = clone.GetComponent<Text>();

					eventText.text = "Перевернуть подопечного";
				}

				var gymCount = patient.NortonIndex == null ? 0 : patient.NortonIndex < 12 ? 2 : patient.NortonIndex < 14 ? 1 : 0;

				for (int l = 0; l < gymCount; l++)
				{
					var clone = GameObject.Instantiate(this.calendarEvent.gameObject, content.transform);

					var cloneRectTransform = clone.GetComponent<RectTransform>();

					cloneRectTransform.anchoredPosition = new Vector2(cloneRectTransform.anchoredPosition.x, cloneRectTransform.anchoredPosition.y - 960 - (640 * l));

					var eventText = clone.GetComponent<Text>();

					eventText.text = "Гимнастика";
				}
			}

			if (patient.Urinal)
			{
				for (int l = 0; l < 2; l++)
				{
					var clone = GameObject.Instantiate(this.calendarEvent.gameObject, content.transform);

					var cloneRectTransform = clone.GetComponent<RectTransform>();

					cloneRectTransform.anchoredPosition = new Vector2(cloneRectTransform.anchoredPosition.x, cloneRectTransform.anchoredPosition.y - 800 - (960 * l));

					var eventText = clone.GetComponent<Text>();

					eventText.text = "Интимная гигиена";
				}
			}
		}

		this.gameObject.SetActive(true);
	}

	public void ClearCalendar()
	{
		foreach (var clone in contentClones)
		{
			GameObject.Destroy(clone);
		}

		foreach (var clone in instantiatedCalendarStripes)
		{
			GameObject.Destroy(clone.gameObject);
		}
	}

	public CalendarStripeController CreateCalendarStripe(DateTime dateTime)
	{
		var clone = GameObject.Instantiate(this.calendarStripe, this.dateStripeParent);



		var calendarStripeController = clone.GetComponent<CalendarStripeController>();

		calendarStripeController.Initialize(dateTime);


		return calendarStripeController;
	}

	public GameObject CreateCalendarContent()
	{
		var contentClone = GameObject.Instantiate(this.contentStripe, this.scrollRectContent);

		this.contentClones.Add(contentClone);

		return contentClone;
	}
}
