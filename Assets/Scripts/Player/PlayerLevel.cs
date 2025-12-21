using UnityEngine;

public class PlayerLevel : MonoBehaviour
{
    [SerializeField] float baseXpNeeded = 100f;
    [SerializeField] float experience = 0f;
    [SerializeField] float exponent = 1.5f;
    [SerializeField] int level = 1;
    [SerializeField] float difficultyMp = 1f;

    public int Level => level;
    public float Experience => experience;
    public float XpNeeded => baseXpNeeded * Mathf.Pow(level, exponent) * difficultyMp;

    public void AddXp(float amount)
    {
        experience += amount;

        while (experience >= XpNeeded)
        {
            experience -= XpNeeded;
            level++;

            Debug.Log("Level up! Current level: " + level);
        }
    }
}
