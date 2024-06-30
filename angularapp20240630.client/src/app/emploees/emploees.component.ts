import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

interface Json{

  emloees:Emploees[];

}

interface Emploees {
  id: number;
  firstName: string;
  lastName: string;
  middleName: string;
  department: string;
  birthDate: Date;
  hireDate: Date;
  salary: number;
}

@Component({
  selector: 'app-emploees',
  templateUrl: './emploees.component.html',
  styleUrl: './emploees.component.css'
})
export class EmploeesComponent implements OnInit {
  public emploees: Emploees[] = [];

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getEmploees();
  }

  getEmploees() {
    this.http.get<Json>('https://localhost:7242/emploees').subscribe(
      (result) => {
        this.emploees = result.emloees;
        console.log(this.emploees)
      },
      (error) => {
        console.error(error);
      }
    );
  }

  title = 'Сотрудники';
}
