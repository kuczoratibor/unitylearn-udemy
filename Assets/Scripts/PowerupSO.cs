using UnityEngine;

[CreateAssetMenu(fileName = "Powerup", menuName = "PowerupSO")]
public class PowerupSO : ScriptableObject
{
    [SerializeField] string powerupType;
    [SerializeField] float valueChange;
    [SerializeField] float duration;

    public string GetPowerupType() {
        return powerupType;
    }
    public float GetValueChange() {
        return valueChange;
    }
    public float GetDuration() {
        return duration;
    }
}