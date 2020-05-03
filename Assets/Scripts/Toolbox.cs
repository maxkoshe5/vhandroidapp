using UnityEngine;

namespace VHack
{
	public class Toolbox : Singleton<Toolbox>
	{
		private void Start()
		{
			Application.targetFrameRate = 60;
		}
	}
}
