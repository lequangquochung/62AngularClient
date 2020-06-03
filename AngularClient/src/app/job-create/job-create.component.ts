
import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormArray, Validators, FormGroup } from '@angular/forms';
import Swal from 'sweetalert2';

//model
import { Customer } from '../Models/customer.model';
import { Job } from './../Models/job.model';
import { RouterModule, Routes, Router } from '@angular/router';

//service
import { JobService } from '../shared/job.service';
import { CustomerAccountService } from '../shared/customer-account.service';

@Component({
  selector: 'app-job-create',
  templateUrl: './job-create.component.html',
  styleUrls: ['./job-create.component.css']
})
export class JobCreateComponent implements OnInit {

  customerList = [];
  jobForm: FormGroup;

  constructor(private jobService: JobService,
              private customerAccountService: CustomerAccountService,
              private location: Location,
              private fb: FormBuilder,
              private router: Router) { }

  ngOnInit() {
    this.jobForm = this.fb.group({
      job_code: ['', Validators.required],
      job_name: ['', Validators.required],
      job_description: ['', Validators.required]
    });

    this.customerAccountService.getCustomerList().subscribe(
      res => this.customerList = res as []
    )
  }

  onFormSubmit() {
    let job = this.jobForm.value;
    this.createJob(job);
  }

  createJob(job: Job) {
    this.jobService.createJob(job).subscribe(
      (data) => { console.log(data) }
    );
    console.log(job);
    this.confirmRedirect();   
    
  }

  goBack(): void {
    this.location.back();
  }

  
  ///Alert 
  successfully(): void {
    Swal.fire({
      icon: 'success',
      title: 'Successfully !',
      text: 'Created Successfully !',
    })
  }

  confirmRedirect():void{
    Swal.fire({
      title: 'Success',      
      icon: 'success',
      showCancelButton: true,
      confirmButtonColor: '#FF7F50',
      cancelButtonColor: '#3085d6',
      confirmButtonText: 'Back To List',
      cancelButtonText: 'Continue'
    }).then((result) => {
      if (result.value) {
        this.router.navigate(['/joblist']);
      }
      else{
        this.jobForm.reset();
        return;
      }
    })
  }

  cancel(): void {
    Swal.fire({
      title: 'Are you sure?',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Yes'
    }).then((result) => {
      if (result.value) {
        this.location.back();
      }
    })
  }
  // 


}



