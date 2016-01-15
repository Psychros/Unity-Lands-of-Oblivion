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

    private GameObject currentProductionChain = null;   //Save the productionchain that it can be disabled later
    private Building selectedBuilding = null;           //Current building in the building description

    public BuildmenuManager()
    {
        instance = this;
    }

    void Start () {
     
	}

    public void selectBuilding()
    {
        //Select the building
        BuildingManager.instance.selectedBuilding = selectedBuilding;

        //Close the buildmenu
        InputManager.instance.switchToMenu(InputManager.instance.buildmenuPanel, false, true);
        BuildmenuManager.instance.activeMenu = null;
        InputManager.instance.toggleTimeScale();
    }

    /*
     * Show the building description
     */
    public void showBuildingDescription(Building building)
    {
        Debug.Log("Hallo");
        //Enable the building description
        buildingDescription.SetActive(true);

        //Actualize the texts and images
        buildingName.text = Localizer.Instance.GetText("Building." + building.name);
        showCosts(building);
        showProduct(building);

        //Save the selection
        selectedBuilding = building;
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
            WorkBuilding b = (WorkBuilding)building;

            productText.enabled = true;
            product1Image.enabled = true;
            product1Text.enabled = true;

            product1Image.sprite = RessourceManager.Instance.getSprite(b.product);
            product1Text.text    = b.numberProduct.ToString();

            if((int)b.ressource != (int)Ressources.None)
            {
                ressourceText.enabled = true;
                ressource1Image.enabled = true;
                ressource1Text.enabled = true;

                ressource1Image.sprite = RessourceManager.Instance.getSprite(b.ressource);
                ressource1Text.text    = b.numberRessource.ToString();
            } else {
                ressourceText.enabled = false;
                ressource1Image.enabled = false;
                ressource1Text.enabled = false;
            }
        } else {
            productText.enabled = false;
            product1Image.enabled = false;
            product1Text.enabled = false;
            ressourceText.enabled = false;
            ressource1Image.enabled = false;
            ressource1Text.enabled = false;
        }
    }


    /*
     *
     */
     public void showProductionChain(GameObject productionChain)
    {
        //Disable the current production chain
        if(currentProductionChain != null)
            currentProductionChain.SetActive(false);

        //Enable the new production chain
        productionChain.SetActive(true);
        currentProductionChain = productionChain;

        //Disable the building description
        buildingDescription.SetActive(false);
    }
}
