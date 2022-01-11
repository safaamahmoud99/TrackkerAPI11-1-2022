using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data.DTO;
using Tracker.Domain;
using Tracker.Domain.IServices;
using TrackingSystemAPI.DTO;

namespace Tracker.Core.Services
{
    public class RequestService : IRequestService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RequestService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public int AddRequests(RequestDTO requestDTO)
        {
            _unitOfWork.Request.Add(requestDTO);
            return requestDTO.Id;
        }

        public int CountClosedProjects(int projectId)
        {
           return _unitOfWork.Request.CountClosedProjects(projectId);         
        }

        public int CountInProgressProjects(int projectId)
        {
            return _unitOfWork.Request.CountInProgressProjects(projectId);
        }

        public int CountOpenProjects(int projectId)
        {
            return _unitOfWork.Request.CountOpenProjects(projectId);
        }

        public int CountProjects(int projectId)
        {
            return _unitOfWork.Request.CountProjects(projectId);
        }

        public void DeleteRequests(int id)
        {
            _unitOfWork.Request.Delete(id);
        }

        public IEnumerable<RequestDTO> GetAllRequestByClientId(int ClientId)
        {
            return _unitOfWork.Request.GetAllRequestByClientId(ClientId);
        }

        public IEnumerable<RequestDTO> GetAllRequestByProjectId(int ProjectId)
        {
            return _unitOfWork.Request.GetAllRequestByProjectId(ProjectId);
        }

        public IEnumerable<RequestDTO> GetAllRequestByProjectSiteAssetId(int ProjectSiteAssetId)
        {
            return _unitOfWork.Request.GetAllRequestByProjectSiteAssetId(ProjectSiteAssetId);
        }

        public List<RequestDTO> GetAllRequestByProjectTeamId(ProjectTeamVM model)
        {
            return _unitOfWork.Request.GetAllRequestByProjectTeamId(model);
        }

        public List<RequestDTO> GetAllRequestByRequestStatus(int requestStatusId)
        {
            return _unitOfWork.Request.GetAllRequestByRequestStatus(requestStatusId);
        }

        public RequestDTO GetAllRequestByRequestStatusAndProjectTeamId(int requestStatusId, int ProjectTeamId)
        {
            return _unitOfWork.Request.GetAllRequestByRequestStatusAndProjectTeamId(requestStatusId, ProjectTeamId);
        }

        public IEnumerable<RequestDTO> GetAllRequests()
        {
            return _unitOfWork.Request.GetAll();
        }

        public IEnumerable<RequestDTO> GetProjectTeamsByProjectId(int ProjectId)
        {
            return _unitOfWork.Request.GetProjectTeamsByProjectId(ProjectId);
        }

        public RequestDTO GetRequestById(int id)
        {
            return _unitOfWork.Request.GetById(id);
        }

        public void UpdateRequests(int Id, RequestDTO requestDTO)
        {
            _unitOfWork.Request.Update(Id,requestDTO);
        }
    }
}
