using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiseaseDataPlatform.WebApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DiseaseDataPlatform.WebApi.Controllers
{ 
    [Controller]
    public class BaseController : ControllerBase
    {
        /// <summary>
        /// 获取错误返回值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="message"></param>
        /// <returns></returns>
        protected ResponseDto<T> GetErrorResponse<T>(string message)
        {
            return new ResponseDto<T>()
            {
                code = ConstResponseCode.Failure,
                message = message,
                data = default(T),
            }; 
        }
        /// <summary>
        /// 获取成功结果
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="message"></param>
        /// <returns></returns>
        protected ResponseDto<T> GetSuccessResponse<T>(string message)
        {
            return new ResponseDto<T>()
            {
                code = ConstResponseCode.Success,
                message = message,
                data=default(T),
            };
        }
    }
}