import { Component, OnInit } from '@angular/core';
import { CustomerModel } from '../models/customer.model';
import { ActivatedRoute } from '@angular/router';
import { CustomerService } from '../services/customer.service';

@Component({
  selector: 'app-customer-detail',
  templateUrl: './customer-detail.component.html',
  styleUrls: ['./customer-detail.component.scss']
})
export class CustomerDetailComponent implements OnInit {
  customer: CustomerModel;

  constructor(
    private route: ActivatedRoute,
    private readonly customerService: CustomerService) {
  }

  ngOnInit() {
    this.customerService.getCustomer(this.route.snapshot.params.id)
      .subscribe(customer => this.customer = customer);
  }
}
