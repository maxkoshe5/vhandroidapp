using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class IndexWizardController : MonoBehaviour
{
	public Text BartelIndexLabel;
	public int WizardIndex = 0;
	public Text ResultText;
	public WizardType WizardTypeField;

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
		ResultText.text = ResolveText();
	}

	private string ResolveText()
	{
		if (WizardTypeField == WizardType.Fall)
		{
			if (new int[] { 0, 1, 2, 3, 4 }.Contains(WizardIndex))
			{
				return "нет риска падения";
			}
			if (new int[] { 5, 6, 7, 8 }.Contains(WizardIndex))
			{
				return "умеренный риск падения(необходимо составление программы по предотвращению падений)";
			}
			if (new int[] { 9, 10, 11, 12 }.Contains(WizardIndex))
			{
				return "высокий риск падения(необходимо исполнять программу по предотвращению падений)";
			}
			return "нет риска падения";
		}

		if (WizardTypeField == WizardType.Norton)
		{
			if (new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }.Contains(WizardIndex))
			{
				return "очень вероятно образование пролежней";
			}
			if (new int[] { 13, 14 }.Contains(WizardIndex))
			{
				return "имеется опасность образования пролежней";
			}
			if (new int[] { 15, 16, 17, 18, 19, 20 }.Contains(WizardIndex))
			{
				return "Опасность образования пролежней невелика";
			}
			return "Опасность образования пролежней невелика";
		}

		if (WizardTypeField == WizardType.Bartel)
		{
			if (new int[] { 0, 1, 2, 3 }.Contains(WizardIndex))
			{
				return "полная зависимость от посторонних. Человеку нужно помогать во всех повседневных действиях. При отсутствии у него деменции уходу за ним нужно уделять минимум 5 часов в сутки.";
			}
			if (new int[] { 4,5, 6, 7, 8,9,10,11 }.Contains(WizardIndex))
			{
				return "выраженная зависимость от посторонней помощи.Помогать нужно, как минимум, трижды в день – для приема, приготовления пищи и передвижения.На это необходимо затрачивать 3 часа в день.Плюс к этому нужно помогать по хозяйству – 3 - 4 раза в неделю, по 2 - 3 часа каждый раз.";
			}
			if (new int[] { 12, 13, 14, 15,16 }.Contains(WizardIndex))
			{
				return "умеренная зависимость. Такому человеку нужно помогать, как минимум, в двух процессах(смотрите по шкале – где стоят «0»).Это можно делать однократно в течение дня, что по времени займет не менее 90 минут в сутки.Несколько раз в течение недели необходимо также осуществлять помощь по хозяйству.Это займет еще 2 - 3 часа каждый раз.";
			}
			if (new int[] { 17, 18 }.Contains(WizardIndex))
			{
				return "слабая зависимость от помощи окружающих.Это означает, что нужно приехать и помочь 1 - 2 раза в течение недели, проконтролировать купленные продукты и наличие готовой пищи в холодильнике.";
			}
			if (new int[] { 19, 20 }.Contains(WizardIndex))
			{
				return "в помощи окружающих не нуждается.";
			}
			return "нет риска падения";
		}
		return "в помощи окружающих не нуждается.";
	}

	/// <summary>
	/// Тип опросника
	/// </summary>
	public enum WizardType
	{
		/// <summary>
		/// Индекс Бартела
		/// </summary>
		[Description("Индекс Бартела")]
		Bartel = 0,
		/// <summary>
		/// Риск падения
		/// </summary>
		[Description("Риск падения")]
		Fall = 1,
		/// <summary>
		/// Риск возникновения пролежней
		/// </summary>
		[Description("Риск возникновения пролежней")]
		Norton = 2,
		/// <summary>
		/// Анализ когнитивных способностей
		/// </summary>
		[Description("Анализ когнитивных способностей")]
		Demention = 3

	}
}

