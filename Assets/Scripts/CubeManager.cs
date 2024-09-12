using UnityEngine;

public class CubeManager : MonoBehaviour
{
    private Stat attackStat;
    private Stat defenseStat;
    private Broker broker;

    void Start()
    {
        attackStat = new Stat(50f);
        defenseStat = new Stat(50f);

        broker = new Broker();
        broker.AddStat(attackStat);
        broker.AddStat(defenseStat);

        Debug.Log("Cube initialized with Attack: " + attackStat.GetValue() + " Defense: " + defenseStat.GetValue());
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("AttackBoost"))
        {
            attackStat.AddModifier(new AttackModifier(10f));
            Debug.Log("Attack boosted by 10");
            Destroy(other.gameObject);
        }
        else if(other.gameObject.CompareTag("DefenseBoost"))
        {
            defenseStat.AddModifier(new DefenseModifier(10f));
            Debug.Log("Defense boosted by 10");
            Destroy(other.gameObject);
        }
    }
}