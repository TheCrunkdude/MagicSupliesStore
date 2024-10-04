import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-mainpage-component',
  templateUrl: './mainpage-component.html',
  styleUrl: './mainpage-component.css'
})

export class MainpageComponent implements OnInit{
  
  ngOnInit(): any {
    
    document.getElementById("ClassMain")?.remove()
    console.log('Mainpage funcionando')

    
  }

}
