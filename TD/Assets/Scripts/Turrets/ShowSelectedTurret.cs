using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowSelectedTurret : MonoBehaviour
{
    [Header("Unity Setup Fields")]
    public Button StandardTurretButton;
    public Button MissileLauncherButton;
    public Color turretSelectedColor;
    public Color turretUnSelectedColor;

    void Update()
    {
        if(ShopView.isShopOpened && Input.GetKeyDown(KeyCode.B))
        {
            StandardTurretButton.image.color = turretUnSelectedColor;
            MissileLauncherButton.image.color = turretUnSelectedColor;
        }
    }

    public void ClickStandardButtonColor()
    {
        StandardTurretButton.image.color = turretSelectedColor;

        MissileLauncherButton.image.color = turretUnSelectedColor;
    }

    public void ClickMissileLauncherButton()
    {
        MissileLauncherButton.image.color = turretSelectedColor;

        StandardTurretButton.image.color = turretUnSelectedColor;
    }
}
