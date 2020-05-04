using Assets.Scripts.Managers;
using UnityEngine;

namespace VHack
{
	public class Toolbox : Singleton<Toolbox>
	{
		public string authToken;
		public string sessionId;

		private void Start()
		{
			Application.targetFrameRate = 60;
		}
	}
}
