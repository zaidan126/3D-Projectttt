using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class humanunit : Unit
{
    private ResourcePile package;
    public float productivity_multiplayer = 2;
    protected override void BuildingInRange()
    {
        if(package == null)
        {
            ResourcePile pile = m_Target as ResourcePile;
            if(pile != null)
            {
                package = pile;
                package.ProductionSpeed *= productivity_multiplayer;
            }
        }
    }
    void resetproductivity()
    {
         if(package!= null)
         {
            package.ProductionSpeed /= productivity_multiplayer;
            package = null;
         }
    }
    public override void GoTo(Building target)
    {
        resetproductivity();
        base.GoTo(target);
    }

    public override void GoTo(Vector3 position)
    {
        resetproductivity();
        base.GoTo(position);
    }

}
