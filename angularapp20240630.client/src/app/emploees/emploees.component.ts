import { HttpClient } from '@angular/common/http';
import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import $ from 'jquery';
import 'bootstrap';
import 'bootstrap-table';
// import 'bootstrap-table-filter-control';


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

  @ViewChild('table') table : ElementRef | undefined;
  
  public emploees: Emploees[] = [];

  constructor(private http: HttpClient, private elementRef: ElementRef) { }

  ngOnInit() {
    this.getEmploees();
  }

  getEmploees() {
    this.http.get<Json>('https://localhost:4242/emploees').subscribe(
      (result) => {
        this.emploees = result.emloees;
        if(this.table){
          $(this.table.nativeElement).bootstrapTable({data: this.emploees})
        }
        console.log(this.emploees)
      },
      (error) => {
        console.error(error);
      }
    );
  }

  title = 'Сотрудники';
}
