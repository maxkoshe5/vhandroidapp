﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class BartelIndexWizardController : MonoBehaviour
{
	public int BartelIndex = 0;
	private Stack<int> lastIndexIncrement = new Stack<int>();

	// Start is called before the first frame update
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void AddIndex(int index)
	{
		lastIndexIncrement.Push(index);
		BartelIndex += index;
	}

	public void ClearLastSelectionIncrement()
	{
		BartelIndex -= lastIndexIncrement.Pop();
	}
}
