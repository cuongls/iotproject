using System;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace IOTProject.DanhMuc.Dtos
{
	[AutoMapFrom(typeof(DM_TRANGTHAI)), AutoMapTo(typeof(DM_TRANGTHAI))]
    public class DM_TRANGTHAIDto : EntityDto<long>
    {
         public string NAME { get; set; }
 public string CODE { get; set; }
 public string DESCRIPTION { get; set; }
 public int TenantId { get; set; }

    }
}
