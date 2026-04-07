using UnityEngine;

public class AlarmHandler : MonoBehaviour
{
    [SerializeField] private CarpetAlarm _carpetAlarm;
    [SerializeField] private Alarmer _alarmer;

    private void OnEnable()
    {
        _carpetAlarm.CarpetTouched += OnCarpetTouched;
        _carpetAlarm.CrookWent += OnCrookWent;
    }

    private void OnDisable()
    {
        _carpetAlarm.CarpetTouched -= OnCarpetTouched;
        _carpetAlarm.CrookWent -= OnCrookWent;
    }

    private void OnCarpetTouched()
    {
        _alarmer.RunIncreaseAlarm();
    }

    private void OnCrookWent()
    {
        _alarmer.RunDecreaseAlarm();
    }
}
