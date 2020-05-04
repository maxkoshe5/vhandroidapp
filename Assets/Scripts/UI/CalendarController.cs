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

					cloneRectTransform.sizeDelta = new Vector2(cloneRectTransform.sizeDelta.x, 60);
					cloneRectTransform.anchoredPosition = new Vector2(cloneRectTransform.anchoredPosition.x, cloneRectTransform.anchoredPosition.y - 220 - (160 * k));

					var eventText = clone.GetComponent<Text>();

					eventText.text = "Перевернуть подопечного";
				}

				var gymCount = patient.NortonIndex < 12 ? 2 : patient.NortonIndex < 14 ? 1 : 0;

				for (int l = 0; l < gymCount; l++)
				{
					var clone = GameObject.Instantiate(this.calendarEvent.gameObject, content.transform);

					var cloneRectTransform = clone.GetComponent<RectTransform>();

					cloneRectTransform.sizeDelta = new Vector2(cloneRectTransform.sizeDelta.x, 40);

					cloneRectTransform.anchoredPosition = new Vector2(cloneRectTransform.anchoredPosition.x, cloneRectTransform.anchoredPosition.y - 900 - (640 * l));

					var eventText = clone.GetComponent<Text>();

					eventText.text = "Гимнастика";
				}
			}

			if (patient.UrinalDevice)
			{
				for (int l = 0; l < 6; l++)
				{
					var clone = GameObject.Instantiate(this.calendarEvent.gameObject, content.transform);

					var cloneRectTransform = clone.GetComponent<RectTransform>();

					cloneRectTransform.sizeDelta = new Vector2(cloneRectTransform.sizeDelta.x, 40);
					cloneRectTransform.anchoredPosition = new Vector2(cloneRectTransform.anchoredPosition.x, cloneRectTransform.anchoredPosition.y - 120 - (320 * l));

					var eventText = clone.GetComponent<Text>();

					eventText.text = "Опорожнить мочеприемник";
				}
			}


			// TODO: Питание
			for (int e = 0; e < 5; e++)
			{
				var clone = GameObject.Instantiate(this.calendarEvent.gameObject, content.transform);

				var cloneRectTransform = clone.GetComponent<RectTransform>();

				cloneRectTransform.sizeDelta = new Vector2(cloneRectTransform.sizeDelta.x, 40);
				cloneRectTransform.anchoredPosition = new Vector2(cloneRectTransform.anchoredPosition.x, cloneRectTransform.anchoredPosition.y - 800 - (160 * e));

				var eventText = clone.GetComponent<Text>();

				eventText.text = "Прием пищи";
			}

			// TODO: Чистка зубов
			for (int l = 0; l < 2; l++)
			{
				var clone = GameObject.Instantiate(this.calendarEvent.gameObject, content.transform);

				var cloneRectTransform = clone.GetComponent<RectTransform>();

				cloneRectTransform.sizeDelta = new Vector2(cloneRectTransform.sizeDelta.x, 40);
				cloneRectTransform.anchoredPosition = new Vector2(cloneRectTransform.anchoredPosition.x, cloneRectTransform.anchoredPosition.y - 730 - (960 * l));

				var eventText = clone.GetComponent<Text>();

				eventText.text = "Чистка зубов";
			}

			// TODO: Мытьё головы
			if (i > 0 && i - 1 % 4 == 0)
			{
				var clone = GameObject.Instantiate(this.calendarEvent.gameObject, content.transform);

				var cloneRectTransform = clone.GetComponent<RectTransform>();

				cloneRectTransform.sizeDelta = new Vector2(cloneRectTransform.sizeDelta.x, 40);
				cloneRectTransform.anchoredPosition = new Vector2(cloneRectTransform.anchoredPosition.x, cloneRectTransform.anchoredPosition.y - 1760);

				var eventText = clone.GetComponent<Text>();

				eventText.text = "Мытьё головы";
			}

			// TODO: Маникюр и педикюр
			if (i > 1 && i - 2 % 8 == 0)
			{
				var clone = GameObject.Instantiate(this.calendarEvent.gameObject, content.transform);

				var cloneRectTransform = clone.GetComponent<RectTransform>();

				cloneRectTransform.sizeDelta = new Vector2(cloneRectTransform.sizeDelta.x, 40);
				cloneRectTransform.anchoredPosition = new Vector2(cloneRectTransform.anchoredPosition.x, cloneRectTransform.anchoredPosition.y - 1060);

				var eventText = clone.GetComponent<Text>();

				eventText.text = "Маникюр и педикюр";
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
