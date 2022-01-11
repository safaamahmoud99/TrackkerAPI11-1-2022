import { Component, OnInit } from '@angular/core';
import { observable } from 'rxjs';
import { employee } from 'src/Shared/Models/employee';
import { client } from 'src/Shared/Models/client';
import { organization } from 'src/Shared/Models/organization';
import { projectType } from 'src/Shared/Models/projectType';
import { OrganizationService } from 'src/Shared/Services/organization.service';
import { ClientService } from 'src/Shared/Services/client.service';
import { EmployeeService } from 'src/Shared/Services/employee.service';
import { MessageService } from 'primeng/api';
import { ProjectService } from 'src/Shared/Services/project.service';
import { Router } from '@angular/router';
import { ProjectTypeService } from 'src/Shared/Services/project-type.service';
import { StackholdersService } from 'src/Shared/Services/stackholders.service';

import { stackholder } from 'src/Shared/Models/stackeholder';
import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';

@Component({
  selector: 'app-create-project',
  templateUrl: './create-project.component.html',
  styleUrls: ['./create-project.component.css']
})
export class CreateProjectComponent implements OnInit {
  projectObj: any;
  lstClients: client[];
  lstOrganizations: organization[];
  OrganizationObj: organization;
  stackholderInLst:stackholder
  lstOfStackholder:stackholder[]
  lstEmployees: employee[];
  EmployeeObj: employee;
  lstProjectTypes: projectType[];
  ProjectTypeObj: projectType;
  projectID: any
  constructor(private projectService: ProjectService, private organizationService: OrganizationService,
    private clientService: ClientService,private stackholderService: StackholdersService, private employeeService: EmployeeService, private projectTypeService: ProjectTypeService
    , private messageService: MessageService, private router: Router) { }

  ngOnInit(): void {
    this.lstOfStackholder = []
    this.projectObj = {
      id: 0, projectName: "", projectCode: "", projectTypeName: "", projectTypeId: 0, cost: 0, projectPeriod: 0, planndedStartDate: new Date()
      , actualStartDate: new Date(), planndedEndDate: new Date(), actualEndDate: new Date(), description: "", organizationId: 0, employeeId: 0, clientId: 0
    }
    this.stackholderInLst = {
      description:'',id:0,mobile:'',projectId:0,rank:'',stackeholderName:''
    }
    this.organizationService.GetAllOrganizations().subscribe(
      res => { this.lstOrganizations = res },
      err => console.log(err)
    )
    this.clientService.GetAllClients().subscribe(
      res => { this.lstClients = res },
      err => console.log(err)
    )
    this.employeeService.GetAllEmployees().subscribe(
      res => { this.lstEmployees = res },
      err => console.log(err)
    )
    this.projectTypeService.GetAllProjectTypes().subscribe(
      data => { this.lstProjectTypes = data },
      err => console.log(err)
    )
  }
  AddProject() {
    //this.showSuccess();
    // this.projectObj.organizationId = Number(this.projectObj.organizationId);
    // this.projectObj.clientId = Number(this.projectObj.clientId);
    // this.projectObj.employeeId = Number(this.projectObj.employeeId);
    // console.log("organizationId",this.projectObj.organizationId);
    this.projectService.AddProject(this.projectObj).subscribe(
      (res) => {
        this.projectID = res
        this.stackholderInLst.projectId=this.projectID
        console.log(this.projectID)
        this.messageService.add({ severity: 'success', summary: 'Success', detail: 'Record Added' });
        // this.router.navigate(['home/tabs']);
      },
      err => console.log(err),
    );
  }

  showSuccess() {
    this.messageService.add({ severity: 'success', summary: 'Success', detail: 'Record Added' });
  }

  showInfo() {
    this.messageService.add({ severity: 'info', summary: 'Info', detail: 'Message Content' });
  }

  showWarn() {
    this.messageService.add({ severity: 'warn', summary: 'Warn', detail: 'Message Content' });
  }

  showError() {
    this.messageService.add({ severity: 'error', summary: 'Error', detail: 'Message Content' });
  }

  showCustom() {
    this.messageService.add({ severity: 'custom', summary: 'Custom', detail: 'Message Content', icon: 'pi-file' });
  }

  showTopLeft() {
    this.messageService.add({ key: 'tl', severity: 'info', summary: 'Info', detail: 'Message Content' });
  }

  showTopCenter() {
    this.messageService.add({ key: 'tc', severity: 'warn', summary: 'Warn', detail: 'Message Content' });
  }

  showBottomCenter() {
    this.messageService.add({ key: 'bc', severity: 'success', summary: 'Success', detail: 'Message Content' });
  }

  showConfirm() {
    this.messageService.clear();
    this.messageService.add({ key: 'c', sticky: true, severity: 'warn', summary: 'Are you sure?', detail: 'Confirm to proceed' });
  }
  onConfirm() {
    this.messageService.clear('c');
  }

  onReject() {
    this.messageService.clear('c');
  }
  Savetolist(){
    this.lstOfStackholder.push(this.stackholderInLst);    
  }
  SaveToDB(){
    
    this.stackholderService.insertListOfStackholders(this.lstOfStackholder).subscribe(e=>{
    })
  }
}
