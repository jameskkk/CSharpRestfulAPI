﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using System.Threading.Tasks;

/************************************************************************************
* Autor：John
* Version：V1.0.0.0
* CreateTime：2020/10/30
* Copyright © 2020  All Rights Reserved
************************************************************************************/
namespace RestFulService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Single, IncludeExceptionDetailInFaults = true)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class PersonInfoQueryServices : IPersonInfoQuery
    {
        private List<User> UserList = new List<User>();
        /// <summary>
        /// 生成一些測試數據
        /// </summary>
        public PersonInfoQueryServices()
        {
            UserList.Add(new User() { ID = 1, Name = "張三", Age = 18, Score = 98 });
            UserList.Add(new User() { ID = 2, Name = "李四", Age = 20, Score = 80 });
            UserList.Add(new User() { ID = 3, Name = "王二麻子", Age = 25, Score = 59 });
        }
        /// <summary>
        /// 實現GetScore方法，返回某人的成績
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public User GetScore(string name)
        {
            return UserList.FirstOrDefault(n => n.Name == name);
        }
        /// <summary>
        /// 實現GetInfo方法，返回某人的User信息
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public User GetInfo(Info info)
        {
            return UserList.FirstOrDefault(n => n.ID == info.ID && n.Name == info.Name);
        }

    }
}
