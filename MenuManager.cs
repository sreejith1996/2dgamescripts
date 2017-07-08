using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {

	public Menu CurrentMenu;

	public void Start(){
		ShowMenu (CurrentMenu);
	}

	public void LoadLevel(){
		Application.LoadLevel ("level_2");
	}

	public void ShowMenu(Menu menu){
		if (CurrentMenu != null)
			CurrentMenu.isOpen = false;

		CurrentMenu = menu;
		CurrentMenu.isOpen = true;
	}
}
