import { NgForm } from '@angular/forms';
import { Component, ViewChild, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'write-data',
    templateUrl: './writedata.component.html',
    styleUrls: ['./writedata.component.css']
})

export class WriteDataComponent {
  public policies: Policy[];

  phoneNumberIds: number[] = [1];

  @ViewChild('myForm')
  private myForm: NgForm;
  private _baseUrl: string;

  constructor(private http: Http, @Inject('BASE_URL') baseUrl: string) {
    this._baseUrl = baseUrl;
  }
  
  types: any[] = [
    { id: 0, name: 'Site Built Home', value: 0 },
    { id: 1, name: 'Modular Home', value: 1 },
    { id: 2, name: 'Single Wide Manufactured Home', value: 2 },
    { id: 3, name: 'Double Wide Manufactured Home', value: 3 }
  ];

  curType: any = this.types[0]; // first will be selected by default, if it feels like displaying it that is....
  
  setNewValue(id: any): void {
    if (id == null) return;
    console.log(id);
    this.curType = this.types.filter(value => value.id === parseInt(id));
    console.log(this.curType[0].value);
  } 
  

  preparePostData(data: PostPolicy) {
    console.log(data);
    let postData: PostPolicy = data;
    return postData;
  }

  registrationCallback(status: number, statusText: string | null) {
    if (status === 201) {
      this.myForm.reset();
      alert("Successful update of the database! Clear the form and notify the user.");
    } else {
      alert("Something went wrong... " + statusText);
    }
  }


  register(myForm: NgForm) {
    if (myForm.valid) {
      let response: JSON;
      this.http.post(this._baseUrl + 'api/Policy', this.preparePostData(myForm.value)).subscribe(result => {
        response = result.json();
        if ((<any>result)._body.value != null) {
          alert("Something went completely sideways! " + (<any>result)._body.value);
        }
          this.registrationCallback(result.status, result.statusText);
          console.log("Response: " + JSON.stringify(response));
        },
        error => console.error(error));
    } 
  }

}

class PostPolicy {
  PolicyNumber: number;
  PolicyEffectiveDate: Date;
  PolicyExpirationDate: Date;
  PrimaryInsuredName: string;
  PrimaryInsuredMailingAddress: string;
  PrimaryInusredCity: string;
  PrimaryInsuredState: string;
  PrimaryInsuredZipCode: string;
  RiskConstruction: number;
  RiskYearBuilt: number;
  RiskAddress: string;
  RiskCity: string;
  RiskState: string;
  RiskZipCode: string;
}

interface Policy {
  policyNumber: number;
  primaryInsuredName: string;
  policyEffectiveDate: Date;
  policyExpirationDate: Date;
};