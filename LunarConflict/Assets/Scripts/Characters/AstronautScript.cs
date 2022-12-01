using System.Collections;
using UnityEngine;

public class AstronautScript : GenericUnitScript
{
    [SerializeField] private GameObject blackhole;

    public void OpenBlackHole()
    {
        StartCoroutine(CreateBlackHole());
    }

    private IEnumerator CreateBlackHole()
    {
        yield return null;
        
        var startScale = blackhole.transform.localScale;
        blackhole.transform.localScale /= 10.0f;
        var increaseVal = blackhole.transform.localScale;
        
        blackhole.SetActive(true);

        while (blackhole.transform.localScale.magnitude < startScale.magnitude)
        {
            blackhole.transform.localScale += increaseVal;
            yield return new WaitForSeconds(0.005f);
        }
    }
}
