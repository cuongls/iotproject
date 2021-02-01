using Abp.Web.Mvc.Views;

namespace IOTProject.Web.Views
{
    public abstract class IOTProjectWebViewPageBase : IOTProjectWebViewPageBase<dynamic>
    {

    }

    public abstract class IOTProjectWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected IOTProjectWebViewPageBase()
        {
            LocalizationSourceName = IOTProjectConsts.LocalizationSourceName;
        }
    }
}