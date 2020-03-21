using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiseaseDataPlatform.DiseaseEntity;
using DiseaseDataPlatform.WebApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DiseaseDataPlatform.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        private DiseaseDataContext _Context;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="context"></param>
        public UserController(DiseaseDataContext context)
        {
            _Context = context;
        }
        /// <summary>
        /// 添加新用户
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        [HttpPost("addUser")]
        public ResponseDto<object> AddUser(AddUserView view)
        {
            var result = new ResponseDto<object>() {
                code = ConstResponseCode.Failure, 
            };
            if (string.IsNullOrEmpty(view.name))
            {
                result.message = "name can not  be empty";
                return result;
            }
            if (string.IsNullOrEmpty(view.password))
            {
                result.message = "password can not be empty";
                return result;
            }
            if (string.IsNullOrEmpty(view.email))
            {
                result.message = "email can not be empty";
                return result;
            }
            var existsUser = _Context.User.Where(p=>p.Email==view.email).FirstOrDefault();
            if (existsUser != null)
            {
                result.message = "the user is exists";
            }
            _Context.User.Add(new DiseaseEntity.User()
            {
                Id = Guid.NewGuid(),
                Email = view.email,
                Name = view.name,
                Password = view.password,  //密码请加密吧！！
                Phone = view.phone,
                Sex = view.sex,
                Status = 1,
                Enabled = 1,
                Created = DateTime.Now,
                LastModified=DateTime.Now,
            }) ; 
            _Context.SaveChanges();
            result.code = ConstResponseCode.Success;
            result.message = "success";
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="view"></param>
        [HttpPost("editUser")]

        public ResponseDto<object> EditUser(EditUserView view)
        { 
            if (view.id == Guid.Empty)
            {
               return GetErrorResponse<object>("wrong parameter");
            }
            if (string.IsNullOrEmpty(view.name))
            {
                return GetErrorResponse<object>("name can not  be empty"); 
            } 
            if (string.IsNullOrEmpty(view.email))
            {
                return GetErrorResponse<object>("email can not be empty"); 
            }
            var user = _Context.User.Where(p => p.Id == view.id).FirstOrDefault();
            if (user == null)
            {
                return GetErrorResponse<object>("the use is not exists");
            }
            var existsUser = _Context.User.Where(p => p.Email == view.email&&p.Id!=view.id).FirstOrDefault();
            if (existsUser != null)
            {
                return GetErrorResponse<object>("the email has been used");
            }
            user.Email = view.email;
            user.Name = view.name;
            user.Phone = view.phone;
            user.Sex = view.sex;
            user.LastModified = DateTime.Now;
            _Context.SaveChanges();
            return GetSuccessResponse<object>("success");
            
        }
    }
}