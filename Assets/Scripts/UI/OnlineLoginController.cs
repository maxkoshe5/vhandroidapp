using Assets.Scripts.API;
using UnityEngine;
using UnityEngine.UI;
using VHack;

public class OnlineLoginController : MonoBehaviour
{
	public InputField nameInput;
	public InputField surnameInput;
	public InputField patronymicInput;
	public InputField phoneInput;

	public void RequestAuth()
	{
		var authModel = new AuthRequest()
		{
			FirstName = nameInput.text,
			MiddleName = surnameInput.text,
			LastName = patronymicInput.text,
			Phone = phoneInput.text,
		};

		StartCoroutine(PostRequestUtil.PostRequest("https://vera-web-api.azurewebsites.net/api/Auth", JsonUtility.ToJson(authModel)));
	}
}
