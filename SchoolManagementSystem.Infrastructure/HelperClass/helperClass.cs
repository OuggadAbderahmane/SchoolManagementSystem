using Microsoft.AspNetCore.Http;
using SchoolManagementSystem.Data.Entities;
using SchoolManagementSystem.Data.Responses;
using System.Linq.Expressions;

namespace SchoolManagementSystem.Infrastructure.HelperClass
{
    public class helperClass : IHelperClass
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public helperClass(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public string GetSchemeHost()
        {
            return _contextAccessor.HttpContext!.Request.Scheme + "://" + _contextAccessor.HttpContext!.Request.Host;
        }

        public static Expression<Func<StudentEvaluation, GetStudentEvaluationResponse>> expressionStudentEvaluationResponse = x => new GetStudentEvaluationResponse
        {
            Id = x.Id,
            StudentFulName = x.Student.FirstName + x.Student.LastName,
            StudentId = x.StudentId,
            Semester = x.Semester.Name,
            SubjectName = x.Subject.Name,
            SubjectId = x.SubjectId,
            Year = x.Year.Value,
            ContinuousAssessment = x.ContinuousAssessment,
            FirstTest = x.FirstTest,
            SecondTest = x.SecondTest,
            Exam = x.Exam
        };

        public static Expression<Func<SubjectTeacher, GetSubjectTeacherResponse>> expressionSubjectTeacherResponse = x => new GetSubjectTeacherResponse
        {
            Id = x.Id,
            SubjectID = x.SubjectId,
            SubjectName = x.Subject.Name,
            TeacherFullName = x.Teacher.FirstName + ' ' + x.Teacher.LastName,
            TeacherID = x.TeacherId
        };
    }
}
