using System;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace IOTProject.DanhMuc.Dtos
{
	[AutoMapFrom(typeof(DM_ThietBi)), AutoMapTo(typeof(DM_ThietBi))]
    public class DM_ThietBiDto : EntityDto<long>
    {
         public long IDTRAM { get; set; }
         public DM_TRAMDto TRAM { get; set; }
         public string NAME { get; set; }
         public string CODE { get; set; }
         public string IP { get; set; }
         public string PORT_INFO { get; set; }
         public string DESCRIPTION { get; set; }
         public int TenantId { get; set; }
    }
}
