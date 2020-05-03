using System;
using System.Collections;

using UnityEngine;
using UnityEngine.Networking;

namespace Assets.Scripts.API
{
	public class PostRequestUtil<T> where T : class
	{
		public string url;
		public string json;
		public Action<T> onRequestFinished;

		public PostRequestUtil(string url, string json, Action<T> onRequestFinished)
		{
			this.url = url;
			this.json = json;
			this.onRequestFinished = onRequestFinished;
		}

		public T result;

		public IEnumerator PostRequest()
		{
			var uwr = new UnityWebRequest(url, "POST");
			byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
			uwr.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
			uwr.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
			uwr.SetRequestHeader("Content-Type", "application/json");

			//Send the request then wait here until it returns
			yield return uwr.SendWebRequest();

			if (uwr.isNetworkError)
			{
				result = null;
				Debug.Log("Error While Sending: " + uwr.error);
			}
			else
			{
				result = JsonUtility.FromJson<T>(uwr.downloadHandler.text);
				onRequestFinished(result);
				Debug.Log("Received: " + uwr.downloadHandler.text);
			}
		}
	}
}