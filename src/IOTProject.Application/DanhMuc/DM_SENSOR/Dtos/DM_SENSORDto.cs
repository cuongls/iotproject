using System;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace IOTProject.DanhMuc.Dtos
{
	[AutoMapFrom(typeof(DM_SENSOR)), AutoMapTo(typeof(DM_SENSOR))]
    public class DM_SENSORDto : EntityDto<long>
    {
         public string NAME { get; set; }
 public string CODE { get; set; }
 public string DESCRIPTION { get; set; }
 public int TenantId { get; set; }

    }
}
