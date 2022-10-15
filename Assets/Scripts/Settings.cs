using UnityEngine;

[CreateAssetMenu(menuName = "Settings", fileName = "Settings", order = 51)]

public class Settings : ScriptableObject
{
    [SerializeField] private float _spinTimeReel1 = 1.5f;
    [SerializeField] private float _spinTimeReel2 = 2f;
    [SerializeField] private float _spinTimeReel3 = 2.5f;
    [SerializeField] private float _spinTimeReel4 = 3f;
    [SerializeField] private float _spinTimeReel5 = 3.5f;

    public float SpinTimeReel1 => _spinTimeReel1;
    public float SpinTimeReel2 => _spinTimeReel2;
    public float SpinTimeReel3 => _spinTimeReel3;
    public float SpinTimeReel4 => _spinTimeReel4;
    public float SpinTimeReel5 => _spinTimeReel5;
}
