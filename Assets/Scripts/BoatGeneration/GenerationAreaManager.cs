using UnityEngine;

public class GenerationAreaManager : MonoBehaviour
{
    [SerializeField] private GameObject _pointPrefab;
    [SerializeField] private Vector2 _areaSize;
    private float _x, _y, _angle;
    private float _squareX, _squareY;
    private Vector3 _pointPosition;

    private void Start()
    {
        _x = _areaSize.x;
        _y = _areaSize.y;
        transform.localScale = new Vector3(_x * 2, 0.1f, _y * 2);
        SetPointPosition();
    }

    private void SetPointPosition()
    {
        float a = Random.Range(-_x, _x);
        float b = Random.Range(-_y, _y);
        Debug.Log(a + " ; " + b);
        _pointPosition = new Vector3(a, 0, b);

        CheckPointPosition();
    }

    private void CheckPointPosition()
    {
        if (Vector2.Distance(transform.position, _pointPosition) > GetPointDistance())
        {
            SetPointPosition();
        } else
        {
            GeneratePoint();
        }
    }

    private float GetPointDistance()
    {
        if (_x == 0 || _y == 0) { return 0; }
        _squareX = _x * _x;
        _squareY = _y * _y;
        _angle = Vector3.Angle(transform.position, _pointPosition);

        float a = _angle.SquaredCos() / _squareX;
        float b = _angle.SquaredSin() / _squareY;
        float distance = 1 / (a + b);

        Debug.Log(_angle + " - " + distance);
        return distance;
    }

    private void GeneratePoint()
    {
        Instantiate(_pointPrefab, _pointPosition, Quaternion.identity);
    }
}
