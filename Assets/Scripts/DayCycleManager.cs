using UnityEngine;

[ExecuteAlways]
public class DayCycleManager : MonoBehaviour
{
    [SerializeField] private Light _directionalLight;
    [SerializeField] private Gradient _ambientColor, _directionalColor, _fogColor;
    [SerializeField, Range(0, 24)] private float _timeOfDay;

    private void Update()
    {
        if (Application.isPlaying)
        {
            _timeOfDay += Time.deltaTime / 30;
            if (_timeOfDay >= 24) { _timeOfDay = 0; }
            UpdateLighting(_timeOfDay / 24);
        }
    }

    private void UpdateLighting(float timePercent)
    {
        RenderSettings.ambientLight = _ambientColor.Evaluate(timePercent);
        RenderSettings.fogColor = _fogColor.Evaluate(timePercent);

        if (_directionalLight != null)
        {
            _directionalLight.color = _directionalColor.Evaluate(timePercent);
            _directionalLight.transform.localRotation = Quaternion.Euler((timePercent * 360) - 90, 170, 0);
        }
    }

    /*private void OnValidate()
    {
        if (_directionalLight != null) { return; }
        if (RenderSettings.sun != null) { _directionalLight = RenderSettings.sun; }
    }*/
}