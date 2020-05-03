using UnityEngine;

namespace GravityCoaster
{
	public class Toolbox : Singleton<Toolbox>
	{
		private void Start()
		{
			Application.targetFrameRate = 60;
		}
	}
}
