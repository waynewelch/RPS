import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'fetchdata',
    templateUrl: './fetchdata.component.html'
})
export class FetchDataComponent {
  public policies: Policy[];
  
  constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
    http.get(baseUrl + 'api/Policy').subscribe(result => {
      this.policies = result.json() as Policy[];
    }, error => console.error(error));
  }
}

interface Policy {
  policyNumber : number;
  primaryInsuredName : string;
  policyEffectiveDate: Date;
  policyExpirationDate: Date;
};
