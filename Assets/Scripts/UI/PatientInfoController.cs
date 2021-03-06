﻿using System;
using UnityEngine;
using UnityEngine.UI;

public class PatientInfoController : MonoBehaviour
{
	public Text fioText;
	public Text infoText;
	public Patient patient;
	public CalendarController calendarController;

	public void OpenCalendarForPatient(Patient patient)
	{
		calendarController.CreateNextMonth(patient);
	}

	public void Initialize(Patient patient, CalendarController calendarController)
	{
		this.patient = patient;
		this.fioText.text = $"{patient.Name} {patient.Surname}";
		this.infoText.text = $"{patient.Phone}{Environment.NewLine}{(patient.LyingCondition ? "Малоподвижный" : "")}";
		this.calendarController = calendarController;
	}
}
