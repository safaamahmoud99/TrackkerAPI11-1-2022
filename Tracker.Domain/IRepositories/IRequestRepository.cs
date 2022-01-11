﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracker.Data.DTO;
using Tracker.Data.Models;
using TrackingSystemAPI.DTO;

namespace Tracker.Domain.IRepositories
{
   public interface IRequestRepository 
    {
        IEnumerable<RequestDTO> GetAll();
        RequestDTO GetById(int id);
        IEnumerable<RequestDTO> GetProjectTeamsByProjectId(int ProjectId);
        IEnumerable<RequestDTO> GetAllRequestByProjectId(int ProjectId);
        IEnumerable<RequestDTO> GetAllRequestByClientId(int ClientId);
        List<RequestDTO> GetAllRequestByRequestStatus(int requestStatusId );
         RequestDTO GetAllRequestByRequestStatusAndProjectTeamId(int requestStatusId ,int ProjectTeamId);
        List<RequestDTO> GetAllRequestByProjectTeamId(ProjectTeamVM model);
        IEnumerable<RequestDTO> GetAllRequestByProjectSiteAssetId(int ProjectSiteAssetId);
        //List<ProjectDTO> CountProjects(RequestDTO model);

        int CountProjects(int projectId);
        int CountInProgressProjects(int projectId);
        int CountOpenProjects(int projectId);
        int CountClosedProjects(int projectId);


        Request Find(int id);
        int Add(RequestDTO requestDTO);
        void Update(int Id,RequestDTO requestDTO);
        void Delete(int id);
        void Save();
    }
}
