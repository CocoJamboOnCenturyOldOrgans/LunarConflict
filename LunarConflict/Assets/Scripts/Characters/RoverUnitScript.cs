using System.Collections;
using UnityEngine;

public class RoverUnitScript : GenericUnitScript
{
	[SerializeField] private GameObject teleport;

	public void OpenTeleport()
	{
		StartCoroutine(CreateTeleport());
	}

	private IEnumerator CreateTeleport()
	{
		yield return null;
        
		var startScale = teleport.transform.localScale;
		teleport.transform.localScale /= 100.0f;
		var increaseVal = teleport.transform.localScale;
        
		teleport.SetActive(true);

		while (teleport.transform.localScale.magnitude < startScale.magnitude)
		{
			teleport.transform.localScale += increaseVal;
			yield return new WaitForSeconds(0.005f);
		}
	}
}
