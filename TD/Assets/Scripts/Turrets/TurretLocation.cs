using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretLocation : MonoBehaviour
{
    public GameObject turret;
    private Renderer rend;
    private Color startColor;
    BuildManager buildManager;

    [Header("Unity Setup Fields")]
    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 positionOffset;

    void Start()
    {
        buildManager = BuildManager.instance;
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    void OnMouseDown()
    {
        if(ShopView.isShopOpened == true)
        {
            if (!buildManager.CanBuild)
            {
                Debug.Log("No turret is selected!");
                return;
            }
            if (turret != null)
            {
                Debug.Log("You already have a turret placed there!");
                return;
            }

            buildManager.BuildTurretOn(this);
        }
    }

    void OnMouseEnter()
    {
        if (ShopView.isShopOpened == true)
        {
            if (!buildManager.CanBuild)
            {
                return;
            }
            if (buildManager.HasMoney)
            {
                rend.material.color = hoverColor;
            }
            else
            {
                rend.material.color = notEnoughMoneyColor;
            }
        }
    }

    void OnMouseExit()
    {
        if (ShopView.isShopOpened == true)
        {
            rend.material.color = startColor;
        }
    }
}
