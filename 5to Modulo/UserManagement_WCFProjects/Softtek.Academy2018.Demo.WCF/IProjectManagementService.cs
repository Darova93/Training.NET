using Softtek.Academy2018.Demo.WCF.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Softtek.Academy2018.Demo.WCF
{
    [ServiceContract]
    public interface IProjectManagementService
    {
        [OperationContract]
        CreateProjectResponse CreateProject(CreateProjectRequest request);

        [OperationContract]
        GetProjectResponse GetProject(GetProjectRequest request);
    }
}
