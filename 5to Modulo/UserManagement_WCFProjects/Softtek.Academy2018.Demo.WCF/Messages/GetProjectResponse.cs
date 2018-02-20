using Softtek.Academy2018.Demo.Domain.Model;
using Softtek.Academy2018.Demo.WCF.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Softtek.Academy2018.Demo.WCF.Messages
{
    [DataContract]
    public class GetProjectResponse : BaseResponse
    {
        [DataMember]
        public ICollection<ProjectDTO> Projects { get; set; }
    }
}