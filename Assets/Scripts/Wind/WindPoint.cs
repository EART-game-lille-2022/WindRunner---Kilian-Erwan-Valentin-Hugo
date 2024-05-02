using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class WindPoint : MonoBehaviour
{
    public static List<WindPoint> points = new List<WindPoint>();
    public float windIntensity = 1;

    public float decreaseOverTime = -1;

    private void OnEnable()
    {
        points.Add(this);
    }

    private void OnDisable()
    {
        points.Remove(this);
    }

    public static void GetWeightAt(Vector3 position, out float value, out Vector3 forward)
    {
        float currentWeight = 0;
        value = 0;
        forward = Vector3.zero;
        foreach (var point in points)
        {
            float d = Mathf.Max(0.0001f, (position - point.transform.position).magnitude);
            float weight = 1f / d;
            value += point.windIntensity * weight;
            forward += point.transform.forward * weight;
            currentWeight += weight;
        }
        value /= currentWeight;
        forward /= currentWeight;
    }

    private void Update()
    {
        if (Application.isPlaying && decreaseOverTime > 0)
        {
            windIntensity -= Time.deltaTime * decreaseOverTime;
            if (windIntensity < 0)
            {
                Destroy(gameObject);
            }
        }
    }
}