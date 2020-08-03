import { CustomerType } from './customerType.enum';
import { JobModel } from './job.model';

export interface CustomerModel {
    customerId: number;
    name: string;
    type: CustomerType;
    jobs: JobModel[];
}
