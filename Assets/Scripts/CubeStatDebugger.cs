using UnityEngine;
using System.Collections;

public class CubeStatDebugger : MonoBehaviour
{
    [SerializeField] private Stat attackStat;
    [SerializeField] private Stat defenseStat;

    private void Start()
    {
        // Eğer henüz attack ve defense değerleri atanmadıysa, burada atanabilir
        if (attackStat == null)
            attackStat = new Stat(50f);  // Attack başlangıç değeri 50

        

        if (defenseStat == null)
            defenseStat = new Stat(50f);  // Defense başlangıç değeri 50

         
        
        // Coroutine başlatılır
        StartCoroutine(DebugStatsCoroutine());
    }

    // Her 5 saniyede bir Attack ve Defense değerlerini debuglayan coroutine
    private IEnumerator DebugStatsCoroutine()
    {
        while (true)
        {
            if (attackStat == null || defenseStat == null)
            {
                Debug.LogError("One or both stats are null!");
            }
            else
            {
                Debug.Log($"Attack: {attackStat.GetValue()}");
                Debug.Log($"Defense: {defenseStat.GetValue()}");
            }

            yield return new WaitForSeconds(5f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (attackStat == null || defenseStat == null)
        {
            Debug.LogError("One or both stats are null!");
            return;
        }

        if (other.CompareTag("AttackBoost"))
        {
            attackStat.AddModifier(new AttackModifier(10f));
            Debug.Log("Attack boosted by 10");
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("DefenseBoost"))
        {
            defenseStat.AddModifier(new DefenseModifier(10f));
            Debug.Log("Defense boosted by 10");
            Destroy(other.gameObject);
        }
    }

}
