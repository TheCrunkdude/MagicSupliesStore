import { Component } from "@angular/core";

@Component({
    selector: 'img-slider',
    templateUrl: './componentslider.html',

    styleUrls: ['./componentslider.css']
  })
  export class componentslider  {
    name = 'Angular';
    imageObject = [{
        image: 'https://sanjayv.github.io/ng-image-slider/contents/assets/img/slider/5.jpg',
        thumbImage: 'https://sanjayv.github.io/ng-image-slider/contents/assets/img/slider/5.jpg',
        title: 'Hummingbirds are amazing creatures'
    }, {
        image: 'https://sanjayv.github.io/ng-image-slider/contents/assets/img/slider/9.jpg',
        thumbImage: 'https://sanjayv.github.io/ng-image-slider/contents/assets/img/slider/9.jpg'
    }, {
        image: 'https://sanjayv.github.io/ng-image-slider/contents/assets/img/slider/4.jpg',
        thumbImage: 'https://sanjayv.github.io/ng-image-slider/contents/assets/img/slider/4.jpg',
        title: 'Example with title.'
    },{
        image: 'https://sanjayv.github.io/ng-image-slider/contents/assets/img/slider/7.jpg',
        thumbImage: 'https://sanjayv.github.io/ng-image-slider/contents/assets/img/slider/7.jpg',
        title: 'Hummingbirds are amazing creatures'
    }, {
        image: 'https://sanjayv.github.io/ng-image-slider/contents/assets/img/slider/1.jpg',
        thumbImage: 'https://sanjayv.github.io/ng-image-slider/contents/assets/img/slider/1.jpg'
    }, {
        image: 'https://sanjayv.github.io/ng-image-slider/contents/assets/img/slider/2.jpg',
        thumbImage: 'https://sanjayv.github.io/ng-image-slider/contents/assets/img/slider/2.jpg',
        title: 'Example two with title.'
    }];
  }