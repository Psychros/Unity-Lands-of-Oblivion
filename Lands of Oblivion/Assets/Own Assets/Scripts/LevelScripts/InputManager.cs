using UnityEngine;
using UnityEngine.UI;
using System;

public class InputManager : MonoBehaviour {

	public static InputManager instance { get; private set; }
    public static long count = 0;

	public Transform playerTransform = null;
	public Terrain terrain;
	public GameObject ui;
	private  bool _isMenu = false;
    public bool isMenu { get { return _isMenu; } set { _isMenu = value; } }
	public Canvas currentMenu;
	private bool isPause = false;
	private float timer = 0;
	private float timerTime = 0.2f;

	//All menupanels
	public Canvas inGameCanvas;
	public Canvas buildmenuCanvas;
	public Canvas pausemenuCanvas;
	public Canvas storemenuCanvas;
	public Canvas terrainEditorCanvas;

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
        Debug.Log(count);
    }


    void Update () {
		//Cut tree
		if(Input.GetKeyDown(cutTree)){
			CutTreeEvent userEvent = gameObject.AddComponent<CutTreeEvent>();
            userEvent.execute();
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
			switchToMenu(buildmenuCanvas, false);
			if(isMenu){
				BuildmenuManager.instance.activeMenu = null;
			}
		}

		//Pausemenu
		if(Input.GetKeyDown(pausemenu)){
			switchToMenu(pausemenuCanvas, false);
			toggleTimeScale();
		}

		//Storemenu
		if(Input.GetKeyDown(storemenu)){
			switchToMenu(storemenuCanvas, false);
		}

		//TerrainEditor
		if(Input.GetKeyDown(terrainEditor)){
			switchToMenu(terrainEditorCanvas, false);

			//Activates the TerrainEditor
			if(currentMenu == terrainEditorCanvas)
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


	public void toggleTimeScale(){
		isPause = !isPause;

		if(isPause){
			Time.timeScale = 0;
		} else {
			Time.timeScale = 1;
		}
	}

	public void switchToMenu(Canvas menu, bool showInGame){
		if(menu == currentMenu || currentMenu == null){
			isMenu = !isMenu;
			if(isMenu){
				if(!showInGame)
					inGameCanvas.enabled = false;

				menu.enabled = true;
				currentMenu = menu;
				
			} else {
				inGameCanvas.enabled = true;
				currentMenu.enabled = false;
				currentMenu = null;
			}
		}
	}
}