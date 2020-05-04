using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class IndexWizardController : MonoBehaviour
{
	public Text BartelIndexLabel;
	public int WizardIndex = 0;
		
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
		WizardIndex += index;
		RefreshText();
	}

	public void ClearLastSelectionIncrement()
	{
		WizardIndex -= lastIndexIncrement.Pop();
		RefreshText();
	}

	private void RefreshText()
	{
		BartelIndexLabel.text = WizardIndex.ToString();
	}
}
