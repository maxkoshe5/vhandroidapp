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
	public InputField smsCodeInput;

	private Coroutine authCoroutine;
	private Coroutine smsCoroutine;

	public void RequestAuth()
	{
		if (this.authCoroutine == null)
		{
			var authModel = new AuthRequest()
			{
				FirstName = nameInput.text,
				MiddleName = surnameInput.text,
				LastName = patronymicInput.text,
				Phone = phoneInput.text,
			};

			var req = new PostRequestUtil<AuthResponse>("https://vera-web-api.azurewebsites.net/api/Auth", JsonUtility.ToJson(authModel), this.OnAuthFinished);

			this.authCoroutine = StartCoroutine(req.PostRequest());
		}
	}

	public void RequestSms()
	{
		if (this.smsCoroutine == null)
		{
			var smsModel = new SmsRequest()
			{
				SmsCode = smsCodeInput.text,
				SessionId = Toolbox.Instance.sessionId
			};

			var req = new PostRequestUtil<SmsResponse>("https://vera-web-api.azurewebsites.net/api/Auth/smscode", 
				JsonUtility.ToJson(smsModel), 
				this.OnGetSmsFinished);

			this.authCoroutine = StartCoroutine(req.PostRequest());
		}
	}

	public void OnAuthFinished(AuthResponse authResponse)
	{
		this.authCoroutine = null;

		if (authResponse == null || authResponse.code != 0)
		{
			Debug.Log("Ошибка логина");
		}
		else
		{
			Toolbox.Instance.sessionId = authResponse.sessionId;
			Debug.Log("Логин успешен");
		}
	}

	public void OnGetSmsFinished(SmsResponse smsResponse)
	{
		this.smsCoroutine = null;

		if (smsResponse == null || smsResponse.code != 0)
		{
			Debug.Log("Ошибка смс кода");
		}
		else
		{
			Toolbox.Instance.authToken = smsResponse.token;
			Debug.Log("Смс код принят");
		}
	}
}
