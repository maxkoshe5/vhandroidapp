﻿using System.Collections;

using UnityEngine;
using UnityEngine.Networking;

namespace Assets.Scripts.API
{
	public static class PostRequestUtil
	{
		public static IEnumerator PostRequest(string url, string json)
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
				Debug.Log("Error While Sending: " + uwr.error);
			}
			else
			{
				Debug.Log("Received: " + uwr.downloadHandler.text);
			}
		}
	}
}