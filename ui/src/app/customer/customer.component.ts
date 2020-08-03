import { Component, OnInit, ViewChild } from '@angular/core';
import { FormGroup, FormControl, Validators, AbstractControl, FormBuilder } from '@angular/forms';
import { CustomerService } from '../services/customer.service';
import { CustomerType } from '../models/customerType.enum';
import { CustomerListComponent } from '../customer-list/customer-list.component';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.scss']
})
export class CustomerComponent implements OnInit {
  customerForm: FormGroup;
  customerTypes: { name: string, value: number }[];

  @ViewChild(CustomerListComponent, { static: false })
  customerListComponent: CustomerListComponent;

  get customerName(): AbstractControl {
    console.log(this.customerForm.get('customerName'));
    return this.customerForm.get('customerName');
  }

  get customerType(): AbstractControl {
    return this.customerForm.get('customerType');
  }

  constructor(private readonly customerService: CustomerService,
              private readonly formBuilder: FormBuilder) {
    const keys = Object.keys(CustomerType).filter(k => typeof CustomerType[k as any] === 'number');
    this.customerTypes = keys.map(k => ({ name: k, value: CustomerType[k] }));

    this.customerForm = this.formBuilder.group({
      customerName: this.formBuilder.control('', [Validators.required, Validators.minLength(5)]),
      customerType: this.formBuilder.control('', [Validators.required])
    });
  }

  ngOnInit() {
  }

  onSubmit() {
    if (this.customerForm.valid) {
      this.customerService.createCustomer({
        customerId: null,
        name: this.customerName.value,
        type: this.customerType.value,
        jobs: null
      }).subscribe(() => {
        this.customerForm.reset();
        this.customerListComponent.loadCustomers();
      });
    }
  }
}
