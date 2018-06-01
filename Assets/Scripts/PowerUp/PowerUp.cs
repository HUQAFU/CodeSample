using UnityEngine;
using System;

/// <summary>
/// Power ups base class
/// \author Adik
/// </summary>
public abstract class PowerUp : MonoBehaviour
{
    #region Variables
    /// <summary>
    /// power up Title - can be useful for power up upgrades and etc.
    /// </summary>
    public string Title = "Title";
    /// <summary>
    /// duration of power up
    /// </summary>
    public float Duration = 10;
    /// <summary>
    /// Lifetime - for UI and etc.
    /// </summary>
    public float LifeTime { get; private set; } = 0;

    /// <summary>
    /// events for UI subscribing and etc.
    /// </summary>
    event Action<PowerUp> OnBonusActivated;
    event Action<PowerUp> OnBonusDeactivated;
    #endregion

    #region Unity Messages 
    private void OnEnable()
    {
        //There you can get duration from upgrades manager and etc.
        //Duration = PowerUPUpgradeManager.GetPUPDuration(Title);
        OnActivateAction();
        OnBonusActivated?.Invoke(this);
    }


    /// <summary>
    /// Check lifetime of power up - in these case power up just instansiates on object. 
    /// </summary>
    private void Update()
    {
        if (LifeTime < Duration)
        {
            OnUpdateAction();
            LifeTime += Time.deltaTime;
        }
        else
        {
            //Dummy stop magnet
            Destroy(this);
        }
    }

    private void OnDisable()
    {
        OnDeactivateAction();
        OnBonusDeactivated?.Invoke(this);
    }
    #endregion

    #region Protected Methods
    /// <summary>
    /// For logic in inherit classes
    /// </summary>
    protected abstract void OnActivateAction();
    protected abstract void OnUpdateAction();
    protected abstract void OnDeactivateAction();
    #endregion
}
