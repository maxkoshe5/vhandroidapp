using UnityEngine;

namespace VHack
{
	public class Toolbox : Singleton<Toolbox>
	{
		public SaveManager saveManager;

		public string authToken;
		public string sessionId;

		public float uiwidth = 640;
		public float uiheight = 480;

		private void Start()
		{
			Application.targetFrameRate = 60;
		}

		private void OnApplicationQuit()
		{
			saveManager.Save();
		}
	}
}
