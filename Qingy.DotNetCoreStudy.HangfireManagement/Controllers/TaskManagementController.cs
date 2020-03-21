using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Helpers;
using Hangfire;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Qingy.DotNetCoreStudy.HangfireJobEntity;
using Qingy.DotNetCoreStudy.HangfireManagement.Model;

namespace Qingy.DotNetCoreStudy.HangfireManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskManagementController : ControllerBase
    {
        private HangfireJobEntity.HangfireTaskContext _Context = null;
        public TaskManagementController(HangfireTaskContext context)
        {
            _Context = context;
        }
        #region 任务组

        /// <summary>
        /// 添加任务组
        /// </summary>
        /// <param name="groupName"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        [HttpPost("addTaskGroup")]
        public ResultDto<object> AddTaskGroup(string groupName, string description)
        {
            ResultDto<object> result = new ResultDto<object>()
            {
                data = null,
                success = false,
                message = "",
            };
            if (string.IsNullOrEmpty(groupName))
            {
                result.message = "不能为空";
                result.success = false;
                return result;
            }
            var group = _Context.HangfireTaskGroup.FirstOrDefault(p => p.GroupName == groupName);
            if (group != null)
            {
                result.success = false;
                result.message = "该组已经存在";
                return result;
            }
            else
            {
                _Context.HangfireTaskGroup.Add(new HangfireTaskGroup()
                {
                    Id = Guid.NewGuid(),
                    GroupName = groupName,
                    Description = description,
                    Created = DateTime.Now,
                    LastModified = DateTime.Now,
                });
                _Context.SaveChanges();
                result.success = true;
                result.message = "success";
                return result;
            }
        }
        /// <summary>
        /// 获取任务组
        /// </summary>
        /// <param name="groupName"></param> 
        /// <returns></returns>
        [HttpGet("getGroup")]
        public ResultDto<List<TaskGroupModel>> GetTaskGroup(string groupName)
        {
            var query = _Context.HangfireTaskGroup.AsNoTracking();
            if (!string.IsNullOrWhiteSpace(groupName))
            {
                query = query.Where(p => p.GroupName.StartsWith(groupName));
            }
            var groups = query.ToList();
            ResultDto<List<TaskGroupModel>> result = new ResultDto<List<TaskGroupModel>>()
            {
                success = false,
                data = new List<TaskGroupModel>()
            };
            if (groups != null)
            {
                groups.ForEach(p => result.data.Add(new TaskGroupModel()
                {
                    id = p.Id,
                    groupName = p.GroupName,
                    description = p.Description,
                    created = p.Created,
                    lastModified = p.LastModified,
                }));
            }
            result.success = true;
            return result;
        }
        #endregion

        #region 任务
        /// <summary>
        /// 添加任务
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("addTask")]
        public ResultDto<object> AddTask(CreateJobModel model)
        {
            var result = new ResultDto<object>()
            {
                success = false,
                data = null,
            };
            #region 验证执行类

            ////return typeof(ReflectionHelper).Assembly.GetTypes() //获取当前类库下所有类型
            ////   .Where(t => typeof(T).IsAssignableFrom(t)) //获取间接或直接继承t的所有类型
            ////   .Where(t => !t.IsAbstract && t.IsClass) //获取非抽象类 排除接口继承
            ////   .Select(t => (T)Activator.CreateInstance(t)); //创造实例，并返回结果（项目需求，可删除）
            var assembly = Assembly.GetExecutingAssembly();
            var types = assembly.GetTypes();
            var type = types.FirstOrDefault(p => typeof(IJob).IsAssignableFrom(p) && p.FullName == model.executeClassName);

            if (type == null)
            {
                result.success = false;
                result.message = "参数错误，作业对应类不存在";
                return result;
            }
            //else
            //{
            //    //TODO保存数据
            //    //var t= Activator.CreateInstance(type) as  IJob;
            //    // RecurringJob.AddOrUpdate<IJob>(model.name, p => t.Execute(), model.cron,TimeZoneInfo.Local,model.queueName);
            //}
            //// RecurringJob.AddOrUpdate<IDiseaseService>("SyncDiseaseDataToFile", p => p.SyncToFile(), "0 9,12,18,0 * * ?");

            #endregion


            if (string.IsNullOrWhiteSpace(model.name))
            {
                result.message = "任务名称不可以为空";
                result.success = false;
                return result;
            }
            var existTask = _Context.HangfireTask.FirstOrDefault(p => p.Name == model.name);
            if (existTask != null)
            {
                result.message = "已经存在同名的任务！";
                result.success = false;
                return result;
            }
            var group = _Context.HangfireTaskGroup.FirstOrDefault(p => p.Id == model.groupId);
            if (group == null)
            {
                result.message = "任务组不存在";
                result.success = false;
                return result;
            }
            _Context.HangfireTask.Add(new HangfireTask()
            {
                Id = Guid.NewGuid(),
                Name = model.name,
                GroupId = model.groupId,
                Queue = string.IsNullOrEmpty(model.queueName) ? "default" : model.queueName,
                Arguments = model.argument,
                ExecuteClassName = model.executeClassName,
                Description = model.desciption,
                Created = DateTime.Now,
                LastModified = DateTime.Now,
            });
            _Context.SaveChanges();
            result.success = true;
            return result;

        }
        /// <summary>
        /// 获取指定组内作业信息
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns> 
        [HttpGet("getTaskByGroupId")]
        public ResultDto<List<TaskModel>> GetTaskByGroupId(Guid groupId)
        {
            var result = new ResultDto<List<TaskModel>>()
            {
                success = false,
                data = new List<TaskModel>(),
            };
            var taskList = _Context.HangfireTask.Where(p => p.GroupId == groupId).ToList();
            if (taskList != null)
            {
                foreach (var task in taskList)
                {
                    var taskModel = new TaskModel()
                    {
                        id = task.Id,
                        arguments = task.Arguments,
                        taskName = task.Name,
                        groupId = task.GroupId,
                        executeClassName = task.ExecuteClassName,
                        description = task.Description,
                        created = task.Created,
                        LastModified = task.LastModified,
                        triggerList = new List<TaskTriggerModel>(),
                    };
                    if (task.TriggerList != null)
                    {
                        task.TriggerList.ForEach(p => taskModel.triggerList.Add(new TaskTriggerModel
                        {
                            id = p.Id,
                            name = p.Name,
                            cron = p.Cron,
                            status = p.Status,
                            taskId = p.HangfireTaskId,
                            description = p.Description,
                            created = p.Created,
                            lastModified = p.LastModified,
                        }));
                    }
                    result.data.Add(taskModel);
                }
             
            }
            result.success = true;
            return result;
        }
        /// <summary>
        /// 根据Id获取任务
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("getTaskById")]
        public ResultDto<TaskModel> GetTaskById(Guid id)
        {
            var result = new ResultDto<TaskModel>()
            {
                success = false,
                data = new TaskModel(),
            };
            var task = _Context.HangfireTask.Include(p=>p.TriggerList).FirstOrDefault(p => p.Id == id);
            if (task != null)
            {
                result.data = new TaskModel()
                {
                    id = task.Id,
                    arguments = task.Arguments,
                    taskName = task.Name,
                    groupId = task.GroupId,
                    executeClassName = task.ExecuteClassName,
                    description = task.Description,
                    created = task.Created,
                    LastModified = task.LastModified,
                    triggerList=new List<TaskTriggerModel>(),
                };
                if (task.TriggerList != null)
                {
                    task.TriggerList.ForEach(p => result.data.triggerList.Add(new TaskTriggerModel
                    {
                        id=p.Id,
                        name=p.Name,
                        cron=p.Cron,
                        status=p.Status,
                        taskId=p.HangfireTaskId,
                        description=p.Description,
                        created=p.Created,
                        lastModified=p.LastModified,
                    }));
                }
            }
            result.success = true;
            return result;
        }

        /// <summary>
        /// 删除任务
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("deleteTask")]
        public ResultDto<object> DeleteTask(Guid id)
        {
            var result = new ResultDto<object>() {success=false,};
            var task = _Context.HangfireTask.Include(p=>p.TriggerList).FirstOrDefault(p => p.Id == id);
            if (task == null)
            {
                result.success = false;
                result.message = "任务不存在";
                return result;
            }
            else if (task.TriggerList != null && task.TriggerList.Any(p => p.Status == 1))
            {
                result.success = false;
                result.message = "部分触发器还在执行中，请先停止触发器再操作";
                return result;
            }
            else
            {
                if (task.TriggerList != null)
                {
                    _Context.HangfireTaskTrigger.RemoveRange(task.TriggerList);
                }
                _Context.HangfireTask.Remove(task);
                _Context.SaveChanges();
                result.success = true;
                result.message = "删除成功";
                return result;
            }
        }
        #endregion

        #region Trigger
        /// <summary>
        /// 创建触发器
        /// </summary>
        /// <param name="createTriggerModel"></param>
        /// <returns></returns>
        [HttpPost("createTrigger")]
        public ResultDto<object> CreateTrigger(CreateTriggerModel createTriggerModel)
        {

            var result = new ResultDto<object>() { success = false };
            #region 验证参数
            if (createTriggerModel == null)
            {
                result.message = "参数不可为空";
                result.success = false;
                return result;
            }
            if (string.IsNullOrEmpty(createTriggerModel.name))
            {
                result.message = "触发器名称不可为空";
                result.success = false;
                return result;
            } 
            //TODO验证Cron
            #endregion

            var hangfireTask = _Context.HangfireTask.Include(p => p.TriggerList).FirstOrDefault(p => p.Id == createTriggerModel.taskId);
            if (createTriggerModel == null)
            {
                result.message = "指定的作业不存在";
                result.success = false;
                return result;
            }
            else if (hangfireTask.TriggerList != null && hangfireTask.TriggerList.Any(p => p.Name == createTriggerModel.name))
            {
                result.message = "触发器名称不可重复";
                result.success = false;
                return result;
            }

            _Context.HangfireTaskTrigger.Add(new HangfireTaskTrigger()
            {
                Id = Guid.NewGuid(),
                Name = createTriggerModel.name,
                Description = createTriggerModel.description,
                HangfireTaskId = createTriggerModel.taskId,
                Cron = createTriggerModel.cron,
                Status = 0,
                Created = DateTime.Now,
                LastModified = DateTime.Now,
            });
            _Context.SaveChanges();
            result.message = "创建成功";
            result.success = true;
            return result;
        }
        /// <summary>
        /// 启用作业触发器
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("resumeTrigger")]
        public ResultDto<object> ResumeTrigger(Guid id)
        {
            var result = new ResultDto<object>() { success = false };
            var trigger = _Context.HangfireTaskTrigger.Include(p => p.HangfireTask).FirstOrDefault(p => p.Id == id);
            if (trigger == null)
            {
                result.message = "触发器不存在";
                result.success = false;
                return result;
            }
            else if (trigger.Status == 1)
            {
                result.message = "触发器已经在执行中";
                result.success = false;
                return result;
            }
            else
            {
                var assembly = Assembly.GetExecutingAssembly();
                var types = assembly.GetTypes();
                var jobType = types.FirstOrDefault(p => p.IsAbstract == false && (typeof(IJob)).IsAssignableFrom(p) && p.FullName == trigger.HangfireTask.ExecuteClassName);
                if (jobType == null)
                {
                    result.message = "作业信息错误，无执行者";
                    result.success = false;
                    return result;
                }
               var methodInfo = jobType.GetMethod("Execute"); //mt.Invoke(this, new object[] { pra1, pra2, pra3 }).ToString()
                var instance = Activator.CreateInstance(jobType)  as IJob;
                string queue = string.IsNullOrEmpty(trigger.HangfireTask.Queue) ? "default" : trigger.HangfireTask.Queue;
                RecurringJob.AddOrUpdate(trigger.Id.ToString(),()=> instance.Execute(trigger.HangfireTask.Arguments), trigger.Cron,TimeZoneInfo.Local, queue);
                trigger.Status = 1;
                trigger.LastModified = DateTime.Now;
                _Context.SaveChanges();
                result.success = true;
                result.message = "成功加载触发器";
                return result;
            }
        }
        /// <summary>
        /// 停止触发器
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("stopTrigger")]
        public ResultDto<object> StopTrigger(Guid id)
        {
            // public static void Trigger(string recurringJobId);
            var result = new ResultDto<object>()
            {
                success = false,
            };
            if (id == Guid.Empty)
            {
                result.success = false;
                result.message = "参数错误";
                return result;
            }
            RecurringJob.RemoveIfExists(id.ToString());   //尝试移除
            var trigger = _Context.HangfireTaskTrigger.FirstOrDefault(p => p.Id == id);
            if (trigger == null)
            {
                result.success = false;
                result.message = "触发器不存在";
                return result;
            }
            else
            {
                trigger.Status = 2;
                trigger.LastModified = DateTime.Now;
                _Context.SaveChanges();
                result.success = true;
                result.message = "停止触发器成功";
                return result;
            }
        }
        /// <summary>
        /// 删除触发器
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("deleteTrigger")]
        public ResultDto<object> DeleteTrigger(Guid id)
        {
            var result = new ResultDto<object>()
            {
                success = false,
            };
            if (id == Guid.Empty)
            {
                result.success = false;
                result.message = "参数错误";
                return result;
            }
            var trigger = _Context.HangfireTaskTrigger.FirstOrDefault(p => p.Id == id);
            if (trigger != null)
            {
                if (trigger.Status == 1)
                {
                    result.success = false;
                    result.message = "任务正在执行中，请先停止任务后再操作";
                    return result;
                }
                else
                {
                    RecurringJob.RemoveIfExists(id.ToString());   //尝试移除
                    _Context.HangfireTaskTrigger.Remove(trigger);
                    _Context.SaveChanges();
                    result.success = true;
                    result.message = "成功移除";
                    return result;
                }

            }
            else
            {
                RecurringJob.RemoveIfExists(id.ToString());   //尝试移除
                result.success = false;
                result.message = "触发器不存在";
                return result;
            }
        }

        /// <summary>
        /// 立即触发
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("runImmediately")]
        public ResultDto<object> RunImmediately(Guid id) {

            var result = new ResultDto<object>()
            {
                success = false,
            };
            if (id == Guid.Empty)
            {
                result.success = false;
                result.message = "参数错误";
                return result;
            }
          
            var trigger = _Context.HangfireTaskTrigger.FirstOrDefault(p => p.Id == id);
            if (trigger == null)
            {
                result.success = false;
                result.message = "触发器不存在";
                return result;
            }
            else if (trigger.Status == 1)
            {
                RecurringJob.Trigger(id.ToString());   //立即触发
                trigger.Status = 1;
                trigger.LastModified = DateTime.Now;
                _Context.SaveChanges();
                result.success = true;
                result.message = "触发成功";
                return result;
            }
            else
            {
                result.success = false;
                result.message = "当前状态不可触发，必须先恢复作业才可触发";
                return result;
            }
        }
        #endregion
    }
}