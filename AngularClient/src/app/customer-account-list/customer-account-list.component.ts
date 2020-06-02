import { MatSort, MatPaginator, MatTableDataSource } from '@angular/material/';

import { Job } from './../Models/job.model';
import { Component, OnInit, Output, EventEmitter, ViewChild } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Location } from '@angular/common';
import Swal from 'sweetalert2';
//
import { Customer } from '../Models/customer.model';
//service
import { CustomerAccountService } from '../shared/customer-account.service';



@Component({
  selector: 'app-customer-account-list',
  templateUrl: './customer-account-list.component.html',
  styleUrls: ['./customer-account-list.component.css']
})
export class CustomerAccountListComponent implements OnInit {
  customer: Customer[] = [];

  ELEMENT_DATA: Customer[];

  displayedColumns: string[] = [
    'first_name',
    'last_name',
    'gender',
    'address',
    'city',
    'email',
    'phone_number',
    'description',
    'job_name',
    'imgUrl',
    'customer_id'];

  @ViewChild(MatSort, { static: true }) sort: MatSort;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;

  dataSource = new MatTableDataSource<Customer>(this.ELEMENT_DATA);

  constructor(private customerAccountService: CustomerAccountService,
    private location: Location) { }

  ngOnInit() {
    this.customerAccountService.getCustomerList().subscribe(
      customer => this.dataSource.data = customer as Customer[]
    );
    this.dataSource.sort=this.sort;
    this.dataSource.paginator = this.paginator;
  }

  deleteCustomer(customer_id) {  
    Swal.fire({
      title: 'Are you sure?',
      text: "You won't be able to revert this!",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
      if (result.value) {
        Swal.fire(
          'Deleted!',
          'Your file has been deleted!',
          'success'
        ),this.customerAccountService.deleteCustomter(customer_id).subscribe();      
          this.ngOnInit();
      }
    })  
    
  }

  apllyFilter(filterValue: string){
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }
  

  



  goBack(): void {
    this.location.back();
  }



}
