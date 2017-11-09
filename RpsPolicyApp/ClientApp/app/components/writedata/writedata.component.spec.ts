/// <reference path="../../../../node_modules/@types/jasmine/index.d.ts" />
import { assert } from 'chai';
import { WriteDataComponent } from './writedata.component';
import { TestBed, async, ComponentFixture } from '@angular/core/testing';

let fixture: ComponentFixture<WriteDataComponent>;

describe('WriteData component', () => {
    beforeEach(() => {
      TestBed.configureTestingModule({ declarations: [WriteDataComponent] });
        fixture = TestBed.createComponent(WriteDataComponent);
        fixture.detectChanges();
    });

    it('should display a title', async(() => {
        const titleText = fixture.nativeElement.querySelector('h1').textContent;
        expect(titleText).toEqual('WriteData');
    }));
});
