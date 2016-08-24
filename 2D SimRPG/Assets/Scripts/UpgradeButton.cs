using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class UpgradeButton : MonoBehaviour {
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    //on button click event
    public void UpgradeBtn()
    {
        buildingStats selectedBuilding = MainController.getSelectedObject().GetComponent<buildingStats>();
        if (selectedBuilding.isUpgradeable)
            selectedBuilding.UpgradeBuilding();
        else if (selectedBuilding.isBuildable)
            selectedBuilding.Build();
    }

}
