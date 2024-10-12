﻿using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Data.Responses;

namespace SchoolManagementSystem.Service.Abstracts
{
    public interface IStudentService
    {
        public Task<GetAllStudentInfoResponse> GetStudentByIdAsync(int Id);
        public IQueryable<GetStudentResponse> GetStudentsListResponse(string NationalCardNumber, string FirstName, string LastName, bool? Gender, int SectionId, int GuardianId, bool? IsActive);
        public IQueryable<Student> GetStudentsListIQueryable();
        public Task<bool> IsIdExistAsync(int Id);
        public Task<bool> CreateStudentAsync(int PersonId, int? SectionId = null, int? GuardianId = null, bool IsActive = true);
        public Task<bool> UpdateStudentAsync(int PersonId, int? SectionId = null, int? GuardianId = null, bool? IsActive = null, string? NationalCardNumber = null, string? FirstName = null, string? LastName = null, bool? Gender = null,
                                         DateTime? DateOfBirth = null, string? Address = null, string? ImagePath = null);
        public Task<int> CreateStudentAsync(Student student);
        public Task<bool> DeleteStudentAsync(int Id);
    }
}
