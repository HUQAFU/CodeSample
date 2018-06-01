using UnityEngine;

/// <summary>
/// Component that magnets object to target
/// \author Adik
/// </summary>
public class Magnetable : MonoBehaviour
{
    /// <summary>
    /// Magnetic speed
    /// </summary>
    [SerializeField]
    float _speed = 2;
    /// <summary>
    /// time of random force applied
    /// </summary>
    [SerializeField]
    float _noiseTime = 0.5f;

    //Objects stop magneting if distance < than _minDistanceForStop
    float _minDistanceForStop = 0.25f;
    //Force curve decrease value
    float _forceCurveDecreaseFactor = 20;

    bool _magneting;

    //Random force for nonlinear movement
    Vector3 _randomForce;

    //MoveTo target
    Transform _target;
    //CurrentLifetime of magneting
    float _magnetLifetime;

    #region Unity Messages 
    /// <summary>
    /// Perform magneting - Update used for detail profiling - Courutines has bad profile info - bad for optimisation
    /// </summary>
    private void Update()
    {
        Magneting();
    }
    #endregion

    #region Private Methods
    void Magneting() {
        if (_magneting)
        {
            Vector3 CurrPos = transform.position;
            Vector3 TargetPos = _target.position;

            //extra accuracy (like transform.position == target.position) may provide magnet lag on high speed
            if (Vector3.Distance(CurrPos, TargetPos) > _minDistanceForStop)
            {
                _magnetLifetime += Time.deltaTime;
                float noiseTimeAmount = _magnetLifetime;
                if (noiseTimeAmount >= _noiseTime)
                {
                    noiseTimeAmount = _noiseTime;
                }
                Vector3 _modifRandomForce = _randomForce * (1 - (noiseTimeAmount / _noiseTime));
                float stepSpeed = (_speed * _magnetLifetime);
                transform.position = Vector3.MoveTowards(CurrPos, TargetPos, stepSpeed) + (_modifRandomForce * stepSpeed);
            }
            else
            {
                //Dumme handle stop magneting (imitating of Picked)
                Destroy(gameObject);
            }
        }
    }
    #endregion

    #region Public Methods
    /// <summary>
    /// Start magneting
    /// </summary>
    /// <param name="target">MoveTo target</param>
    public void MagnetTo(Transform target)
    {
        if (!_magneting)
        {
            //Random force for nonlinear movement based on distance
            float force = Vector3.Distance(transform.position, target.position) / _forceCurveDecreaseFactor;
            _randomForce = new Vector3(Random.Range(0, force), Random.Range(force, force * 2), Random.Range(-force, force));
            _target = target;
            _magnetLifetime = 0;
            _magneting = true;
        }
    }
    #endregion
}
