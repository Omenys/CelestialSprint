using UnityEngine;

[CreateAssetMenu(menuName = "Shield Stat")]
public class ShieldChargeStat : ScriptableObject
{
    public int maxShieldCount = 3; //Starting player shield count
    public int currentShieldCount = 3; //Dynamic variable that will change. Will equal to maxShieldCount at the start (will be initialized in player script)

}
