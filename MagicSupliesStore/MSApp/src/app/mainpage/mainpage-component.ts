import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-mainpage-component',
  templateUrl: './mainpage-component.html',
  styleUrl: './mainpage-component.css'
})

export class MainpageComponent implements OnInit{
  isMenuHidden = true;

  ngOnInit(): any {
    
    const menuDiv = document.getElementById("MENUDIVID");
    if (menuDiv) 
      menuDiv.style.display = "revert";

    const backDiv = document.getElementById("back");
    if (backDiv) 
      backDiv.style.background = "revert";

    
  }

}
