export class Dog {
  DogID: number;
  Name: string;
  BreedName: string;
  BirthDate: Date;

  constructor() {
    this.DogID = 0;
    this.Name = '';
    this.BreedName = '';
    this.BirthDate = new Date(0);
  }
}
