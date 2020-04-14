using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitFreeze : MonoBehaviour
{
    public void StartHitFreeze(float F)
    {
        StartCoroutine(HitFreezeProcess(F));
    }
    public IEnumerator HitFreezeProcess(float FreezeDuration)
    {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(FreezeDuration);
        Time.timeScale = 1;
        yield return null;
    }

}
