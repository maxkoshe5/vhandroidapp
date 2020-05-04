using System;
using System.Collections.Generic;
using UnityEngine;

public class CalendarController : MonoBehaviour
{
	public GameObject calendarStripe;
	public GameObject contentStripe;
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
			? this.instantiatedCalendarStripes[this.instantiatedCalendarStripes.Count-1].stripeDateTime.AddDays(1) 
			: DateTime.Now.Date;

		for (int i = 0; i < 31; i++)
		{
			this.instantiatedCalendarStripes.Add(this.CreateCalendarStripe(lastDateTime));
			lastDateTime = lastDateTime.AddDays(1);
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

		var contentClone = GameObject.Instantiate(this.contentStripe, this.scrollRectContent);

		var calendarStripeController = clone.GetComponent<CalendarStripeController>();

		calendarStripeController.Initialize(dateTime);
		this.contentClones.Add(contentClone);

		return calendarStripeController;
	}
}
