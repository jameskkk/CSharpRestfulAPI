using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
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
    [DataContract]
    public class Info
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string Name { get; set; }
    }
}
