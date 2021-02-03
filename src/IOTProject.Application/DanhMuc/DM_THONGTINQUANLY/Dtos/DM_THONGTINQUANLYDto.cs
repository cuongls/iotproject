using System;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace IOTProject.DanhMuc.Dtos
{
	[AutoMapFrom(typeof(DM_THONGTINQUANLY)), AutoMapTo(typeof(DM_THONGTINQUANLY))]
    public class DM_THONGTINQUANLYDto : EntityDto<long>
    {
         public string NAME { get; set; }
 public string CODE { get; set; }
 public string DESCRIPTION { get; set; }
        public int SAPXEP { get; set; }
        public int TenantId { get; set; }

    }
}
