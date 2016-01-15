using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using System;

public class InputManager : MonoBehaviour {

	public static InputManager instance { get; private set; }
    public static long count = 0;

	public Transform playerTransform = null;
	public Terrain terrain;
	public GameObject ui;
	private  bool _isMenu = false;
    public bool isMenu { get { return _isMenu; } set { _isMenu = value; } }
	private bool isPause = false;   

	private float timer = 0;
	private float timerTime = 0.2f;

    public AxeController axeController;

    //All menupanels
    private GameObject currentMenu;
    public GameObject CurrentMenu { get { return currentMenu; } set { currentMenu = value;}  }

    public GameObject inGamePanel;
	public GameObject buildmenuPanel;
	public GameObject pausemenuPanel;
	public GameObject storemenuPanel;
	public GameObject terrainEditorPanel;

	//All KeyCodes
	public KeyCode cutTree			 = KeyCode.Mouse0;
	public KeyCode placeBuilding 	 = KeyCode.Mouse1;
	public KeyCode stopPlaceBuilding = KeyCode.Mouse0;
	public KeyCode editTerrain 		 = KeyCode.Mouse0;

	public KeyCode buildmenu 		 = KeyCode.F;
	public KeyCode pausemenu 		 = KeyCode.Escape;
	public KeyCode storemenu 		 = KeyCode.Tab;
	public KeyCode terrainEditor     = KeyCode.T;
	public KeyCode terrainHeightUp   = KeyCode.Y;
	public KeyCode terrainHeightDown = KeyCode.X;


	void Start () {
        count++;
        InputManager.instance = this;
        Cursor.visible = false;
    }


    void Update () {
		//Cut tree
		if(Input.GetKeyDown(cutTree) && !isPause){
            axeController.triggerCut();
		}

		//Place building
		if(Input.GetKeyDown(placeBuilding)){
			BuildBuildingEvent userEvent = new BuildBuildingEvent();
			userEvent.execute();
		}

		//Stop place building
		if(Input.GetKeyDown(stopPlaceBuilding)){
			//Destroy the building which the player is placing
			Destroy(SetBuildingPositionController.instance.building);
			SetBuildingPositionController.instance.building = null;
		}

		//Buildmenu
		if(Input.GetKeyDown(buildmenu)){
			switchToMenu(buildmenuPanel, false, true);
			if(isMenu){
				BuildmenuManager.instance.activeMenu = null;
			}
            toggleTimeScale();
        }

		//Pausemenu
		if(Input.GetKeyDown(pausemenu)){
			switchToMenu(pausemenuPanel, false, true);
			toggleTimeScale();
		}

		//Storemenu
		if(Input.GetKeyDown(storemenu)){
			switchToMenu(storemenuPanel, false, false);
		}

		//TerrainEditor
		if(Input.GetKeyDown(terrainEditor)){
			switchToMenu(terrainEditorPanel, false, false);

			//Activates the TerrainEditor
			if(currentMenu == terrainEditorPanel)
				TerrainEditor.instance.activateTerrainEditor();
			else
				TerrainEditor.instance.deactivateTerrainEditor();
		}

		//Selected TerrainHeight up
		if(Input.GetKeyDown(terrainHeightUp)){
			if(TerrainEditor.instance.selectedTerrainHeight < TerrainEditor.instance.maxHeight){
				TerrainEditor.instance.editSelectedHeight(1);
				timer = 0;
			}
		}
		if(Input.GetKey(terrainHeightUp)){
			if(TerrainEditor.instance.selectedTerrainHeight < TerrainEditor.instance.maxHeight){
				timer += Time.deltaTime;

				if(timer >= timerTime){
					TerrainEditor.instance.editSelectedHeight(1);
					timer = 0;
				}
			}
		}

		//Selected TerrainHeight down
		if(Input.GetKeyDown(terrainHeightDown)){
			if(TerrainEditor.instance.selectedTerrainHeight > TerrainEditor.instance.minHeight){
				TerrainEditor.instance.editSelectedHeight(-1);
				timer = 0;
			}
		}
		if(Input.GetKey(terrainHeightDown)){
			if(TerrainEditor.instance.selectedTerrainHeight > TerrainEditor.instance.minHeight){
				timer += Time.deltaTime;

				if(timer >= timerTime){
					TerrainEditor.instance.editSelectedHeight(-1);
					timer = 0;
				}
			}
		}

		//Edit terrain
		if(Input.GetKey(editTerrain)){
			if(TerrainEditor.instance.Terrain != null)
				TerrainEditor.instance.editTerrain();
		}
        if (Input.GetKeyUp(editTerrain))
        {
            if (TerrainEditor.instance.Terrain != null)
                TerrainEditor.instance.stopEditing();
        }
    }


    public void testForInteractableObject(float distance)
    {
        try
        {
            //Test for a tree in front of the player with a raycast 
            RaycastHit hit = RayCastManager.startRayCast(distance);

            //Remove a tree if the player is forward of one
            Collider coll = hit.collider;
            if (coll != null)
            {

                GameObject hitObj = coll.transform.parent.gameObject;
                Interactable script = hitObj.GetComponent<Interactable>();

                if (script != null)
                {
                    script.interact();
                }
            }
        }
        catch (NullReferenceException e) { }
    }

	public void toggleTimeScale(){
		isPause = !isPause;

		if(isPause){
			Time.timeScale = 0;

            FirstPersonController fps = playerTransform.gameObject.GetComponentInParent<FirstPersonController>();
            fps.MouseLook.XSensitivity = 0.1f;
            fps.MouseLook.YSensitivity = 0.1f;
        } else {
			Time.timeScale = 1;

            FirstPersonController fps = playerTransform.gameObject.GetComponentInParent<FirstPersonController>();
            fps.MouseLook.XSensitivity = 2f;
            fps.MouseLook.YSensitivity = 2f;
        }
	}

    public void freezePlayer()
    {

    }

    //The GameObject should be a Panel
	public void switchToMenu(GameObject menu, bool showInGame, bool showMouse){
		if(menu == currentMenu || currentMenu == null){
			isMenu = !isMenu;
			if(isMenu){
                if (!showInGame)
                    inGamePanel.SetActive(false);
                if(showMouse)
                    Cursor.visible = true;

                menu.SetActive(true);
                currentMenu = menu;
				
			} else {
                inGamePanel.SetActive(true);
                currentMenu.SetActive(false);
                currentMenu = null;
                Cursor.visible = false;
            }
		}
	}
}