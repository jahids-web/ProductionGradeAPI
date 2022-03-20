﻿using BLL.Request;
using DLL.Models;
using DLL.UniteOfWork;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Utility.Exceptions;

namespace BLL.Services
{
    public interface IStudentService
    {
        Task<Student> InsertAsync(Student Request);
        Task<List<Student>> GetAllAsync();
        Task<Student> UpdateAsync(string email, Student student);
        Task<Student> DeleteAsync(string email);
        Task<Student> GetAAsync(string email);

        //Task<bool> EmailExists(string email);
        //Task<bool> IsIdExists(int id);
    }

    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<Student> InsertAsync(Student student)
        {
            //var student = new Student()
            //{
            //    Email = student.Email,
            //    Name = student.Name,
            //    //DepartmentId = studentRequest.DepartmentId
            //};
            await _studentRepository.CreateAsync(student);
            if(await _studentRepository.SaveCompletedAsync())
            {
                return student;
            }
            throw new ApplicationValidationException("Insert has some Problem");
        }
        public async Task<List<Student>> GetAllAsync()
        {
            return await _studentRepository.GetList();
        }
        public async Task<Student> GetAAsync(string email)
        {
            return await _studentRepository.FindSingLeAsync(x => x.Email == email);
        }
        public async Task<Student> UpdateAsync(string email, Student student)
        {
            var dbStudent = await _studentRepository.FindSingLeAsync(x => x.Email == email);
            if(dbStudent == null)
            {
                throw new ApplicationValidationException("Student Not Found");
            }
            dbStudent.Name = student.Name;
            _studentRepository.Update(dbStudent);
            if(await _studentRepository.SaveCompletedAsync())
            {
                return dbStudent;
            }
            throw new ApplicationValidationException("Update has Some Issue");
        }
        public async Task<Student> DeleteAsync(string email)
        {
            var dbStudent = await _studentRepository.FindSingLeAsync(x => x.Email == email);
            if (dbStudent == null)
            {
                throw new ApplicationValidationException("Student Not Found");
            }
            
            _studentRepository.Delete(dbStudent);
            if (await _studentRepository.SaveCompletedAsync())
            {
                return dbStudent;
            }
            throw new ApplicationValidationException("Delect has Some Issue");
        }

        //public async Task<bool> EmailExists(string email)
        //{
        //    var student = await _studentRepository.FindSingLeAsync(x => x.Email == email);
        //    if (student != null)
        //    {
        //        return true;
        //    }
        //    return false;
        //}

        //public Task<bool> IsIdExists(int id)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
