using System;
using System.Web;
using System.Web.Http;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Web.Common;
using Ninject.Web.Common.WebHost;
using Softtek.Academy.Final.Data.Contracts;
using Softtek.Academy.Final.Data.Implementation;
using Softtek.Academy.Final.Business.Contracts;
using Softtek.Academy.Final.Business.Implementation;
using WebApiContrib.IoC.Ninject;

[assembly:
    WebActivatorEx.PreApplicationStartMethod(
    typeof(Softtek.Academy.Final.WebAPI.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethod(
    typeof(Softtek.Academy.Final.WebAPI.App_Start.NinjectWebCommon), "Stop")]


namespace Softtek.Academy.Final.WebAPI.App_Start
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
            kernel.Bind<ISurveyRepository>().To<SurveyDataRepository>();
            kernel.Bind<IQuestionRepository>().To<QuestionDataRepository>();
            kernel.Bind<IAnswerRepository>().To<AnswerDataRepository>();
            kernel.Bind<IOptionRepository>().To<OptionDataRepository>();

            kernel.Bind<ISurveyService>().To<SurveyService>();
            kernel.Bind<IQuestionService>().To<QuestionService>();
            kernel.Bind<IAnswerService>().To<AnswerService>();
        }
    }
}