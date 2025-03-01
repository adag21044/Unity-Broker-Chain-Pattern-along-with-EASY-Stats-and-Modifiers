using UnityEngine;
using System.Collections;

public class CubeStatDebugger : MonoBehaviour
{
    private Broker broker;
    private Stat attackStat;
    private Stat defenseStat;

    private void Start()
    {
        CubeManager cubeManager = GetComponent<CubeManager>();

        if (cubeManager != null)
        {
            broker = cubeManager.GetBroker();
            attackStat = cubeManager.GetAttackStat();
            defenseStat = cubeManager.GetDefenseStat();
        }
        else
        {
            Debug.LogError("CubeManager bulunamadı! Statler atanamıyor.");
        }

        StartCoroutine(DebugStatsCoroutine());
    }

    private IEnumerator DebugStatsCoroutine()
    {
        while (true)
        {
            Debug.Log($"Attack: {attackStat?.GetValue() ?? 0}");
            Debug.Log($"Defense: {defenseStat?.GetValue() ?? 0}");

            yield return new WaitForSeconds(5f);
        }
    }
}
