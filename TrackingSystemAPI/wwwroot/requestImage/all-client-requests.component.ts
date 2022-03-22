import { HttpClient } from '@angular/common/http';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MessageService } from 'primeng/api';
import { environment } from 'src/environments/environment';
import { client } from 'src/Shared/Models/client';
import { ListProjectSiteAssetClients } from 'src/Shared/Models/ListProjectSiteAssetClients';
import { project } from 'src/Shared/Models/project';
import { ProjectSiteAsset } from 'src/Shared/Models/ProjectSiteAsset';
import { projectTeam } from 'src/Shared/Models/projectTeam';
import { request } from 'src/Shared/Models/request';
import { requestDescription } from 'src/Shared/Models/requestDescription';
import { RequestImage } from 'src/Shared/Models/RequestImages';
import { requestPeriority } from 'src/Shared/Models/requestPeriority';
import { RequestProblems } from 'src/Shared/Models/requestProblems';
import { requestSubCategory } from 'src/Shared/Models/requestSubCategory';
import { Sites } from 'src/Shared/Models/Sites';
import { OrganizationClientsService } from 'src/Shared/Services/organization-clients.service';
import { ProjectSiteAssetService } from 'src/Shared/Services/project-site-asset.service';
import { ProjectTeamService } from 'src/Shared/Services/project-team.service';
import { ProjectService } from 'src/Shared/Services/project.service';
import { RequestDescriptionService } from 'src/Shared/Services/request-description.service';
import { RequestPeriorityService } from 'src/Shared/Services/request-periority.service';
import { RequestSubCategoryService } from 'src/Shared/Services/request-sub-category.service';
import { RequestService } from 'src/Shared/Services/request.service';
import { SiteClientsService } from 'src/Shared/Services/site-clients.service';

@Component({
  selector: 'app-all-client-requests',
  templateUrl: './all-client-requests.component.html',
  styleUrls: ['./all-client-requests.component.scss']
})
export class AllClientRequestsComponent implements OnInit {
  lstRequestDesc: requestDescription[]
  lstRequests: request[]
  lstSites:Sites[]
  clientID: number
  clientName: string
  role: string;
  haveAsset:boolean=false;
  haveTeams:boolean=false;
  NewdecDialogbool: boolean;
  reqImages: RequestImage[]
  NewclientDialogbool: boolean;
  dialogAddRequest: boolean;
  isLinear = false;
  firstFormGroup: FormGroup;
  secondFormGroup: FormGroup;
  projectName: string;
  reqObj: request
  lstProjectTeams: projectTeam[]
  projectObj: project
  projectId: number;
  ProjTeamId: number;
  lstReqSubCategories: requestSubCategory[]
  lstReqPeriorities: requestPeriority[]
  lstAssetsByProject: ListProjectSiteAssetClients[]
  listProjectSiteAssetClients: ListProjectSiteAssetClients[]
  lstClientsByProjectId: client[]
  lstAssetsSerialsByAsset: ProjectSiteAsset[];
  assetId: any;
  projectSiteAssetId: any;
  IsSaveProject: boolean;
  disabledButton: boolean;
  createdById: string;
  reqId: request;
  reqDescriptionObj: requestDescription
  reqImage: RequestImage
  lstRequestImages: RequestImage[]
  LoggedInUserString: string;
  canreq:boolean;
  disableAddbth:boolean;
  siteID:any;
  constructor(private requestService: RequestService, private projectteamservice: ProjectTeamService,
    private requestDescriptionService: RequestDescriptionService, private _formBuilder: FormBuilder,
    private organizationClientsService: OrganizationClientsService, private projectService: ProjectService,
    private ReqSubCatService: RequestSubCategoryService, private projectSiteAssetService: ProjectSiteAssetService,
    private reqPeriorityService:RequestPeriorityService,private siteClientsService: SiteClientsService,
    private messageService: MessageService,private httpClient: HttpClient,
    ) { }
    ngOnInit(): void {
    this.firstFormGroup = this._formBuilder.group({
      firstCtrl: ['', Validators.required]
    });
    this.secondFormGroup = this._formBuilder.group({
      secondCtrl: ['', Validators.required]
    });
    this.disabledButton = false
    this.IsSaveProject= false
    this.projectObj = {
      startDate: new Date, endtDate: new Date, RequestClosedLength: 0, RequestInProgressLength: 0, RequestOpenedLength: 0,
      IsDeleted: false,
      actualEndDate: "", listOfdocuments: [], listofprojectteam: [], id: 0, organizationId: 0, projectPeriod: 0, clientMobile: '', clientName: '', organizationName: '', projectTypeName: '',
      planndedEndDate: ""
      , planndedStartDate: "", projectCode: '', listOfStackholders: [], listOfmilestones: [], projectTypeId: 0,
      projectName: '', actualStartDate: "", clientId: 0, cost: 0, description: '', employeeId: 0
    }
    this.reqObj = {
      requestTypeId: 0, serialNumber: '', createdById: "", createdBy: "", sitename: '', projectSiteAssetId: 0,
      id: 0, projectId: 0, projectName: '', requestCode: '',
      requestName: '', requestPeriority: '', requestPeriorityId: 0,
      requestStatus: '', requestStatusId: 0, requestTime: new Date().getHours() + ':' + new Date().getMinutes(), requestDate: new Date(),
      requestSubCategoryId: 0, requestSubCategoryName: '', assetId: 0, clientId: 0,
      requestTypeName: '', description: '', requestModeId: 0, IsAssigned: false,
      IsSolved: false, RequestProblemObj: new RequestProblems, clientName: '', projectTeamId: 0, teamId: 0, teamName: ''
    }
    this.reqDescriptionObj = {
      descriptionDate: new Date,
      description: '', id: 0, requestId: 0, userId: this.LoggedInUserString
    }
    this.reqImage = {
      id: 0, imageName: '', requestId: 0
    }
    this.lstRequestDesc = []
    this.reqImages = []
    this.lstReqSubCategories = []
    this.lstReqPeriorities = []
    this.lstAssetsByProject = []
    this.listProjectSiteAssetClients = []
    this.lstClientsByProjectId = []
    this.lstAssetsSerialsByAsset=[]
    this.lstRequestImages = []

    console.log("clientID", localStorage.getItem("clientId"))
    this.role = localStorage.getItem("roles")
    this.createdById= localStorage.getItem('loginedUserId')
    this.LoggedInUserString = localStorage.getItem('loginedUserId')
    this.clientID = Number(localStorage.getItem("clientId"))
    this.projectService.clientCanRequest(this.clientID).subscribe(e=>
      {
        this.canreq=e;
        console.log("this.canreqqqqqqqqqqqqqqqqqqqq",this.canreq);
        if(!this.canreq)
        {
            this.disableAddbth=true;
            this.messageService.add({ key: 'tr', severity: 'error',  summary: 'Attention !!!', sticky:true, detail: `sorry,you can't add request until project completed` })
        }
      })

       
      this.requestService.GetRequestsByClientId(this.clientID).subscribe(e => {
        this.lstRequests = e
        console.log("reqs", this.lstRequests)
        this.lstRequests.forEach(element => {
          this.clientName = element.clientName
        });
      })

    this.projectService.GetProjectsByClientId(this.clientID).subscribe(
      res => {
        console.log("res projectObj",res)

        this.projectObj = res,
        this.projectName=this.projectObj.projectName,
        console.log("this.projectName",this.projectName);
        this.projectId = this.projectObj.id
      }
    )
  
    this.siteClientsService.GetAllSitesAssigendbyClient(this.clientID).subscribe(
             res=>{
               this.lstSites=res,
               console.log("this.lstSites",this.lstSites)
             }
          )
  }
  onchangeSite(event)
    {
      this.lstAssetsSerialsByAsset=[];
      this.siteID=event.value
    this.projectSiteAssetService.GetAllProjectSiteAssetBySiteId(event.value,this.projectId).subscribe(
      res => {
        this.lstAssetsByProject = res;
         for(let index=0;index<this.lstAssetsByProject.length;index++)
         {
           if(this.lstAssetsByProject[index].assetId===this.lstAssetsByProject[index+1].assetId)
           {
            this.lstAssetsByProject.splice(index,1)
           }
  
         }    
        console.log("assetsbyprojectandsite",this.lstAssetsByProject);
          }
    )
    }
  GetProjectTeamId(TeamId) {
    this.projectteamservice.GetProjectTeamByProjectIdAndTeamIdAndProjectPositionId(this.projectId, TeamId.value)
      .subscribe(e => {
        this.ProjTeamId = e.id
        this.reqObj.projectTeamId = this.ProjTeamId
      })
  }
  OpendialogAddRequest() {
    // this.organizationClientsService.GetOrganizationProjectsByClientId(this.clientID).subscribe(
    //   res => {
    //     console.log("res",res)
    //     res.forEach(element => {
    //       this.projectName = element.projectName
    //     })
    //   }
    // )
    this.siteClientsService.GetAllAssignedClientsByProjectId(this.projectId).subscribe(
      res => {
        this.lstClientsByProjectId = res
      }
    )
    this.projectSiteAssetService.GetAllProjectSiteAssetByProjectId(this.projectId).subscribe(
      res => {
        this.listProjectSiteAssetClients = res
      }
    )
    this.ReqSubCatService.GetAllSubCategorys().subscribe(e => {
      this.lstReqSubCategories = e
    })
    this.reqPeriorityService.GetAllRequestPeriorties().subscribe(e => {
      this.lstReqPeriorities = e,
      this.reqObj.requestPeriorityId=4;
    })
    this.projectteamservice.GetAllTeamsByProjectID(this.projectId).subscribe(e => {
      this.lstProjectTeams = e
      this.lstProjectTeams = e.reduce((unique, o) => {
        if (!unique.some(obj => obj.teamId == o.teamId)) {
          unique.push(o);
        }
        return unique;
      }, []);
      console.log("lstproTeams", this.lstProjectTeams);
     
    })
    
    this.reqObj = {
      createdById: "", createdBy: "", projectSiteAssetId: 0,
      requestTypeId: 0, serialNumber: '', sitename: '',
      id: 0, projectId: 0, projectName: '', requestCode: '',
      requestName: '', requestPeriority: '', requestPeriorityId: 0,
      requestStatus: '', requestStatusId: 0, requestTime: new Date().getHours() + ':' + new Date().getMinutes(), requestDate: new Date(),
      requestSubCategoryId: 0, requestSubCategoryName: '', assetId: 0, clientId: 0,
      requestTypeName: '', description: '', requestModeId: 0, IsAssigned: false,
      IsSolved: false, RequestProblemObj: new RequestProblems, clientName: '', projectTeamId: 0, teamId: 0, teamName: ''
    }
    this.dialogAddRequest = true
    // this.projectSiteAssetService.GetAllProjectSiteAssetByProjectId(this.projectId).subscribe(
    //   res => {
    //     this.lstAssetsByProject = res
    //   }
    // )
  }
   onChangeAsset(event) {
    this.assetId = event.value
    this.projectSiteAssetId =0
   this.projectSiteAssetService.GetAllAssetsSerialsByProjectId(this.projectId,this.siteID,this.assetId).subscribe(
     res=>{
      this.lstAssetsSerialsByAsset = res,
      console.log("this.lstAssetsSerialsByAsset",this.lstAssetsSerialsByAsset)
     }
   )
   console.log("this.reqObj.projectSiteAssetIdiassettttttttt",this.projectSiteAssetId );

  }
  onChangeSerial(event) {
    console.log("serialNumber",event.value)
    this.projectSiteAssetId = event.value
  }

  AddRequest() {
   this.messageService.clear();
    this.reqObj.requestStatusId = 1  //open
    this.reqObj.requestModeId = 5  //by client

    this.reqObj.projectTeamId = this.ProjTeamId
    this.reqObj.projectId = Number(this.reqObj.projectId)
    this.reqObj.clientId = this.clientID
    this.reqObj.createdById=this.createdById
    this.reqObj.projectSiteAssetId=this.projectSiteAssetId 
    console.log("reqObj",this.reqObj)
    if (this.reqObj.requestName != "" && this.reqObj.clientId != 0 && this.reqObj.description!=null
    && this.reqObj.assetId!=0 && this.reqObj.projectSiteAssetId!=0
      && this.reqObj.requestSubCategoryId != 0 && this.reqObj.requestPeriorityId != 0 && this.reqObj.teamId != 0) {
      this.requestService.inserRequest(this.reqObj).subscribe(e => {
        this.reqId = e;
        this.reqDescriptionObj.requestId =Number(this.reqId) 
        this.reqDescriptionObj.description = this.reqObj.description
        this.requestDescriptionService.AddRequestDescription(this.reqDescriptionObj).subscribe(e => {
          this.reqImage.requestId = Number(this.reqId) ;
          this.IsSaveProject = true
          this.messageService.add({ key: 'tr',severity: 'success', summary: 'Success', detail: 'Request Added Successfully' });
        })
      })
      this.disabledButton = true
    }
    else {
      this.disabledButton = false
      this.messageService.add({ key: 'tr', severity: 'error',  summary: 'Attention !!!', sticky:false, detail: 'Plz Complete Data' });
    }

  }
  public uploadFile = (files) => {
    if (files.length === 0) {
      return;
    }
    let fileToUpload = <File>files[0];
    const formData = new FormData();
    formData.append('file', fileToUpload, fileToUpload.name);
    this.reqImage.imageName = fileToUpload.name;

    this.httpClient.post(environment.uploadImage, formData)
      .subscribe(res => {
        this.messageService.add({ severity: 'success', summary: 'Success', detail: 'Uploaded Successfully' });

        // alert('Uploaded Successfully.');

      });
    this.lstRequestImages.push(this.reqImage);
    this.reqImage = {
      id: 0, imageName: '', requestId:Number(this.reqId) 
    };
  }
  SaveimageToDB() {

    this.requestService.addListRequestImages(this.lstRequestImages).subscribe(e => {
      this.reqObj = {
                createdById: "", createdBy: "", projectSiteAssetId: 0,
                requestTypeId: 0, serialNumber: '', sitename: '',
                id: 0, projectId: 0, projectName: '', requestCode: '',
                requestName: '', requestPeriority: '', requestPeriorityId: 0,
                requestStatus: '', requestStatusId: 0, requestTime: new Date().getHours() + ':' + new Date().getMinutes(), requestDate: new Date(),
                requestSubCategoryId: 0, requestSubCategoryName: '', assetId: 0, clientId: 0,
                requestTypeName: '', description: '', requestModeId: 0, IsAssigned: false,
                IsSolved: false, RequestProblemObj: new RequestProblems, clientName: '', projectTeamId: 0, teamId: 0, teamName: ''
              }
      this.messageService.add({ key: 'tr',severity: 'success', summary: 'Success', detail: 'Image added successfully' });
    })

  }
  CloseStipper()
  {
    this.dialogAddRequest=false
    this.requestService.GetRequestsByClientId(this.clientID).subscribe(e => {
      this.lstRequests = e
      this.IsSaveProject=false;
    })
  }
  ViewMoreDesc(requestID) {
    this.requestDescriptionService.GetAllDescByRequestID(requestID).subscribe(res => {
      console.log("desc", res)
      this.lstRequestDesc = res;
      this.NewdecDialogbool = true;
    })
  }
  ViewImages(reqId: number) {
    console.log(reqId)
    this.requestService.GetRequestImageByRequestId(reqId).subscribe(e => {
      this.reqImages = e
      console.log(this.reqImages)
      this.NewclientDialogbool = true
    })
  }
  viewSingleDoc(imgObj) {
    console.log(imgObj)
    var filePath = `${environment.Domain}wwwroot/requestImage/${imgObj.imageName}`;
    window.open(filePath);
  }
}