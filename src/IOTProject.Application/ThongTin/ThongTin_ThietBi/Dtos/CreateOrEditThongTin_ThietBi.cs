using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;
using IOTProject.DanhMuc.Dtos;

namespace IOTProject.ThongTin.Dtos
{
    [AutoMapFrom(typeof(ThongTin_ThietBi)), AutoMapTo(typeof(ThongTin_ThietBi))]
    public class CreateOrEditThongTin_ThietBi
    {
        public long Id { get; set; }
        
         public long IDTHIETBI { get; set; }
         public DM_ThietBiDto THIETBI { get; set; }
         public long IDTHONGTINQUANLY { get; set; }
         public DM_THONGTINQUANLYDto THONGTINQUANLY { get; set; }
         public string TRANGTHAI { get; set; }
         public string DESCRIPTION { get; set; }
         public int TenantId { get; set; }

    }
}
