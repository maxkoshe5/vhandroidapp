using Assets.Scripts.Managers;
using UnityEngine;

namespace VHack
{
	public class Toolbox : Singleton<Toolbox>
	{
		public APIManager APIManager;

		public string authToken;

		private void Start()
		{
			Application.targetFrameRate = 60;
		}
	}
}
