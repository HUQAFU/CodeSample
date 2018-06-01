using UnityEngine;
/// <summary>
/// Magnet power up sample - works with Magnetable component (for reason below)
/// \author Adik
/// </summary>
public class MagnetPowerUp : PowerUp
{
    #region Variables 
    /// <summary>
    /// LayerMask for OverlapSphere - for optimisation
    /// </summary>
    [SerializeField]
    LayerMask _magnetLayerMask;
    [SerializeField]
    float _magnetRange = 4;
    #endregion

    #region Protected Methods 
    protected override void OnActivateAction() { }

    /// <summary>
    /// Triggers magneting on objects
    /// </summary>
    protected override void OnUpdateAction()
    {
        Collider[] allConsumables = Physics.OverlapSphere(transform.position, _magnetRange, _magnetLayerMask);

        foreach (Collider col in allConsumables)
        {
            //Objects, that we magneting, need to continue moving to target after this powerUp destroyed
            col.GetComponent<Magnetable>()?.MagnetTo(transform);
        }
    }

    protected override void OnDeactivateAction() { }
    #endregion
}
