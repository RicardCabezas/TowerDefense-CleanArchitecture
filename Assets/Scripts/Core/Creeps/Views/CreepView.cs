using Core.Turrets.Views;
using UnityEngine;

public class CreepView : GameView
{
    public string RemainingHealth;
    public Vector3 Position;
    public Color Color;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<ProjectileView>()) //TODO: make sure it works for all views
        {
            //TODO: call release of projectile view so it can go back to the pool
            
            
            //TODO: call received damage use case?
        }
    }
}