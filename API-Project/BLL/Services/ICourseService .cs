//using DLL.Repositories;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using Utility.Exceptions;

//namespace BLL.Services
//{
//    public interface ICourseService
//    {
//        Task<bool> IsNameExists(string name);
//        Task<bool> IsCodeExits(string name);
//        Task<bool> IsIdExits(int id);
//        Task<CourseRepository> AddCourseAsync(CourseInsertRequest request);
//        Task<List<CourseRepository>> GetAllCourseAsync();
//        Task<CourseRepository> FindACourseAsync(string code);
//        Task<bool> DeleteCourseAsync(string code);
//        Task<CourseRepository> UpdateCourseAsync(string code, CourseInsertRequest course);
//    }

//    public class CourseService : ICourseService
//    {
//        private readonly IUnitOfWork _unitOfWork;

//        public CourseService(IUnitOfWork unitOfWork)
//        {
//            _unitOfWork = unitOfWork;
//        }

//        public async Task<bool> IsNameExists(string name)
//        {
//            var department = await _unitOfWork.CourseRepository.GetAAsynce(x => x.Name == name);
//            if (department != null)
//            {
//                return true;
//            }

//            return false;
//        }

//        public async Task<bool> IsCodeExits(string code)
//        {
//            var department = await _unitOfWork.CourseRepository.GetAAsynce(x => x.Code == code);
//            if (department != null)
//            {
//                return true;
//            }

//            return false;
//        }

//        public async Task<bool> IsIdExits(int id)
//        {
//            var department = await _unitOfWork.CourseRepository.GetAAsynce(x => x.CourseId == id);
//            if (department != null)
//            {
//                return true;
//            }

//            return false;
//        }


//        public async Task<CourseRepository> AddCourseAsync(CourseInsertRequest request)
//        {
//            CourseRepository course = new CourseRepository()
//            {
//                Code = request.Code,
//                Name = request.Name
//            };

//            await _unitOfWork.CourseRepository.CreateAsync(course);

//            if (await _unitOfWork.ApplicationSaveChangesAsync())
//            {
//                return course;
//            }
//            throw new MyAppException("Data Insert Unsuccessfully");
//            // return await _unitOfWork.CourseRepository.InsertAsync(course);
//        }

//        public async Task<bool> DeleteCourseAsync(string code)
//        {
//            var course = await _unitOfWork.CourseRepository.GetAAsynce(x => x.Code == code);
//            if (course == null)
//            {
//                throw new MyAppException("Roll wise Student not found");
//            }

//            _unitOfWork.CourseRepository.DeleteAsync(course);
//            if (await _unitOfWork.ApplicationSaveChangesAsync())
//            {
//                return true;
//            }

//            return false;
//        }

//        public async Task<CourseRepository> FindACourseAsync(string code)
//        {
//            return await _unitOfWork.CourseRepository.GetAAsynce(x => x.GetHashCode == code);
//        }

//        public async Task<List<CourseRepository>> GetAllCourseAsync()
//        {
//            return await _unitOfWork.CourseRepository.GetListAsynce();
//        }

//        public async Task<CourseRepository> UpdateCourseAsync(string code, CourseInsertRequest course)
//        {
//            var objcourse = await _unitOfWork.CourseRepository.GetAAsynce(x => x.Code == code);

//            if (objcourse == null)
//            {
//                throw new MyAppException("No found Data");
//            }

//            objcourse.Name = course.Name;

//            _unitOfWork.CourseRepository.UpdateAsyc(objcourse);


//            if (await _unitOfWork.ApplicationSaveChangesAsync())
//            {
//                return objcourse;
//            }
//            throw new MyAppException("Student Data Not save");
//        }
//    }
//}