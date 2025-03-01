using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class CubeManager : MonoBehaviour
{
    [SerializeField] private Stat attackStat;
    [SerializeField] private Stat defenseStat;
    private Broker broker;

    void Start()
    {
        broker = new Broker();

        attackStat = new Stat(50f, broker);
        defenseStat = new Stat(50f, broker);

        Debug.Log("[CUBE MANAGER] Initialized Cube with:");
        Debug.Log($"[CUBE MANAGER] Attack: {attackStat.GetValue()}");
        Debug.Log($"[CUBE MANAGER] Defense: {defenseStat.GetValue()}");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("AttackBoost"))
        {
            broker.AddModifier(new AttackModifier(10f));
            Debug.Log("Attack boosted by 10 through Broker");
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("DefenseBoost"))
        {
            broker.AddModifier(new DefenseModifier(10f));
            Debug.Log("Defense boosted by 10 through Broker");
            Destroy(other.gameObject);
        }
    }

    void Update()
    {
        attackStat.UpdateStat(Time.deltaTime);
        defenseStat.UpdateStat(Time.deltaTime);

        Debug.Log($"Current Attack Power: {attackStat.GetValue()}");
        Debug.Log($"Current Defense Power: {defenseStat.GetValue()}");

        #if UNITY_EDITOR
            EditorUtility.SetDirty(this); // CubeManager değiştiği için Inspector güncellenecek
        #endif
    }

    public Broker GetBroker() => broker;
    public Stat GetAttackStat() => attackStat;
    public Stat GetDefenseStat() => defenseStat;
}
