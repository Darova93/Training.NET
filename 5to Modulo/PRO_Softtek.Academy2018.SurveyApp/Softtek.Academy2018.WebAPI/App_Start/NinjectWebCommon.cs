using System;
using System.Web;
using System.Web.Http;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Web.Common;
using Ninject.Web.Common.WebHost;
using Softtek.Academy2018.SurveyApp.Business.Contracts;
using Softtek.Academy2018.SurveyApp.Business.Implementation;
using Softtek.Academy2018.SurveyApp.Data.Contracts;
using Softtek.Academy2018.SurveyApp.Data.Implementations;

[assembly:
    WebActivatorEx.PreApplicationStartMethod(
    typeof(Softtek.Academy2018.Demo.WebAPI.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethod(
    typeof(Softtek.Academy2018.Demo.WebAPI.NinjectWebCommon), "Stop")]

namespace Softtek.Academy2018.Demo.WebAPI
{
    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Rebind<HttpConfiguration>().ToMethod(
                context => GlobalConfiguration.Configuration);

            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IQuestionRepository>().To<QuestionDataRepository>();
            kernel.Bind<IOptionRepository>().To<OptionDataRepository>();
            kernel.Bind<ISurveyRepository>().To<SurveyDataRepository>();
            kernel.Bind<IQuestionTypeRepository>().To<QuestionTypeDataRepository>();

            kernel.Bind<IQuestionService>().To<QuestionService>();
            kernel.Bind<IOptionService>().To<OptionService>();
            kernel.Bind<ISurveyService>().To<SurveyService>();
            kernel.Bind<IQuestionTypeService>().To<QuestionTypeService>();
        }
    }
}