using UnityEngine;
using UnityEngine.UI;

public class BuildmenuManager : MonoBehaviour {
	public static BuildmenuManager instance;
	public GameObject activeMenu = null;

    public GameObject buildingDescription;
    public Text buildingName;
    public Image cost1Image;
    public Text cost1Text;
    public Image cost2Image;
    public Text cost2Text;
    public Text productText;
    public Image product1Image;
    public Text product1Text;
    public Text ressourceText;
    public Image ressource1Image;
    public Text ressource1Text;

    public BuildmenuManager()
    {
        instance = this;
    }

    void Start () {
     
	}

	public void selectBuilding(string building){
		if(activeMenu != null){
			InputManager.instance.switchToMenu(activeMenu, false, true);
			activeMenu = null;
		} else{
			InputManager.instance.switchToMenu(InputManager.instance.buildmenuPanel, false, true);
		}

		BuildingManager.instance.selectedBuilding = building;
	}


	public void switchToSubmenu(GameObject subMenu){
		//Disable old menu
		if(activeMenu == null)
			InputManager.instance.buildmenuPanel.GetComponent<Canvas>().enabled = false;
		else
			activeMenu.GetComponent<Canvas>().enabled = false;

		subMenu.GetComponent<Canvas>().enabled   = true;
		this.activeMenu = subMenu;
		InputManager.instance.CurrentMenu = activeMenu;
	}


	public void switchToRootmenu(GameObject rootMenu){	
		activeMenu.SetActive(false);
        rootMenu.SetActive(true);
        activeMenu = rootMenu;
		InputManager.instance.CurrentMenu = activeMenu;
	}

    public void showBuildingDescription(Building building)
    {
        buildingDescription.SetActive(true);

        buildingName.text = Localizer.Instance.GetText("Building." + building.name);
        showCosts(building);
        showProduct(building);
    }


    //Show the costs
    private void showCosts(Building building)
    {
        Cost[] costs = building.costs.ToArray();

        //Cost1
        if (costs.Length > 0)
        {
            cost1Image.enabled = true;
            cost1Text.enabled = true;
            cost1Text.text = costs[0].number.ToString();
            cost1Image.sprite = RessourceManager.Instance.getSprite(costs[0].ressource);
        }
        else
        {
            cost1Image.enabled = false;
            cost1Text.enabled = false;
        }

        //Cost2
        if (costs.Length > 1)
        {
            cost2Image.enabled = true;
            cost2Text.enabled = true;
            cost2Text.text = costs[1].number.ToString();
            cost2Image.sprite = RessourceManager.Instance.getSprite(costs[1].ressource);
        }
        else
        {
            cost2Image.enabled = false;
            cost2Text.enabled = false;
        }
    }


    //Show the product
    private void showProduct(Building building)
    {
        if(building is WorkBuilding)
        {
            productText.enabled = true;
            product1Image.enabled = true;
            product1Text.enabled = true;

            WorkBuilding b = (WorkBuilding)building;

            product1Image.sprite = RessourceManager.Instance.getSprite(b.ressource);
            product1Text.text    = b.number.ToString();
        } else {
            productText.enabled = false;
            product1Image.enabled = false;
            product1Text.enabled = false;
            ressourceText.enabled = false;
            ressource1Image.enabled = false;
            ressource1Text.enabled = false;
        }
    }
}
