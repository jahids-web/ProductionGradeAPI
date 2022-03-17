﻿using DLL.Model;
using DLL.Models;
using DLL.UniteOfWork;
using System.Collections.Generic;
using System.Threading.Tasks;
using Utility.Exceptions;

namespace BLL.Services
{
    public interface ICourseService
    {
        Task<Course> InsertAsync(Course course);
        Task<List<Course>> GetAllAsync();
        Task<Course> UpdateAsync(string code, Course course);
        Task<Course> DeleteAsync(string code);
        Task<Course> GetAAsync(string code);

    }

    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<Course> InsertAsync(Course course)
        {
          
            await _courseRepository.CreateAsync(course);
            if (await _courseRepository.SaveCompletedAsync())
            {
                return course;
            }
            throw new ApplicationValidationException("Course insert has some problem");
        }
        public async Task<List<Course>> GetAllAsync()
        {
            return await _courseRepository.GetList();
        }
        public async Task<Course> GetAAsync(string code)
        {
            var course = await _courseRepository.FindSingLeAsync( x=>x.Code==code);
            if (course == null)
            {
                throw new ApplicationValidationException("Course Not Found");
            }
            return course;
        }

        public async Task<Course> UpdateAsync(string code, Course aCourse)
        {
            var course = await _courseRepository.FindSingLeAsync(x => x.Code == code);
            if (course == null)
            {
                throw new ApplicationValidationException("Course Not Found");
            }
            if (!string.IsNullOrWhiteSpace(aCourse.Code))
            {
                var existsAlreasyCode = await _courseRepository.FindSingLeAsync(x => x.Code == aCourse.Code);
                if (existsAlreasyCode != null)
                {
                    throw new ApplicationValidationException("You updated Code alrady present in our systam");
                }
                course.Code = aCourse.Code;
            }

            if (!string.IsNullOrWhiteSpace(aCourse.Name))
            {
                var existsAlreasyCode = await _courseRepository.FindSingLeAsync(x => x.Name == aCourse.Name);
                if (existsAlreasyCode != null)
                {
                    throw new ApplicationValidationException("You updated Name alrady present in our systam");
                }
                course.Name = aCourse.Name;
            }
            _courseRepository.Update(course);
            if (await _courseRepository.SaveCompletedAsync())
            {
                return course;
            }
            throw new ApplicationValidationException("In Update have Some Problem");
        }
        public async Task<Course> DeleteAsync(string code)
        {
            var course = await _courseRepository.FindSingLeAsync(x => x.Code == code);
            if (course == null)
            {
                throw new ApplicationValidationException("Course Not Found");
            }
            _courseRepository.Delete(course);
            if (await _courseRepository.SaveCompletedAsync())
            {
                return course;
            }
            throw new ApplicationValidationException("Some Problem for delete data");
        }
        
      
    }
}
