using System;

using UnityEngine;
using UnityEngine.UI;

public class CalendarStripeController : MonoBehaviour
{
	public DateTime stripeDateTime;
	public Text stripeDateTimeLabel;

	public void Initialize(DateTime stripeDateTime)
	{
		this.stripeDateTime = stripeDateTime;
		this.stripeDateTimeLabel.text = this.stripeDateTime.ToShortDateString();
	}
}
