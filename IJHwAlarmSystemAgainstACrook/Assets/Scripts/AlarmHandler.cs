using UnityEngine;

public class AlarmHandler : MonoBehaviour
{
    [SerializeField] private CarpetAlarm _carpetAlarm;
    [SerializeField] private Alarmer _alarmer;

    private void OnEnable()
    {
        _carpetAlarm.CarpetTouched += _alarmer.RunIncreaseAlarm;
        _carpetAlarm.CrookWent += _alarmer.RunDecreaseAlarm;
    }

    private void OnDisable()
    {
        _carpetAlarm.CarpetTouched -= _alarmer.RunIncreaseAlarm;
        _carpetAlarm.CrookWent -= _alarmer.RunDecreaseAlarm;
    }
}
