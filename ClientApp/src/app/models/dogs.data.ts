export class Dog {
  DogID: number;
  Name: string;
  Breed: string;
  BirthDate: Date;

  constructor() {
    this.DogID = 0;
    this.Name = '';
    this.Breed = '';
    this.BirthDate = new Date(0);
  }
}
