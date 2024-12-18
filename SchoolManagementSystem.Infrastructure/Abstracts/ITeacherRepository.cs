﻿using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Data.Responses;
using SchoolManagementSystem.Infrastructure.Bases;

namespace SchoolManagementSystem.Infrastructure.Abstracts
{
    public interface ITeacherRepository : IGenericRepository<Teacher>
    {
        public Task<GetAllTeacherInfoResponse> GetTeacherByIdAsync(int Id);
        public IQueryable<GetTeacherResponse> GetTeachersListResponse(string FirstName, string LastName, bool? Gender, bool? PermanentWork);
        public IQueryable<Teacher> GetTeachersListIQueryable();
        public bool UpdateTeacherByQuery(int PersonId, bool? PermanentWork = null);
        public Task<bool> AddNewTeacherByPersonAsync(int PersonId, bool PermanentWork);
        public Task<bool> DeleteTeacherAsync(int Id);
    }
}
