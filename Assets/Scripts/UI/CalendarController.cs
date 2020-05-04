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
	public float timeStripeWidth = 240;
	public float timeStripeHeight = 80;

	public void Start()
	{
		this.CreateNextWeek();
	}

	public void CreateNextWeek()
	{
		var lastDateTime = this.instantiatedCalendarStripes.Count > 0 
			? this.instantiatedCalendarStripes[this.instantiatedCalendarStripes.Count-1].stripeDateTime.AddDays(1) 
			: DateTime.Now.Date;

		for (int i = 0; i < 7; i++)
		{
			this.instantiatedCalendarStripes.Add(this.CreateCalendarStripe(lastDateTime));
			lastDateTime = lastDateTime.AddDays(1);
		}
	}

	public CalendarStripeController CreateCalendarStripe(DateTime dateTime)
	{
		var clone = GameObject.Instantiate(this.calendarStripe, this.dateStripeParent);

		var contentClone = GameObject.Instantiate(this.contentStripe, this.scrollRectContent);

		var calendarStripeController = clone.GetComponent<CalendarStripeController>();

		calendarStripeController.Initialize(dateTime);

		return calendarStripeController;
	}
}
