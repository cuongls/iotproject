﻿using System.Linq;
using Abp.Domain.Repositories;
using Abp.Application.Services;
using IOTProject.ThongTin;
using IOTProject.DanhMuc.Dtos;
using System.Collections.Generic;
using AutoMapper;
using Abp.Linq.Extensions;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System.Threading.Tasks;
using Abp.Runtime.Session;
using Abp.UI;
using IOTProject.ThongTin.Dtos;

namespace IOTProject.ThongTin
{
    public class ThongTin_ThietBiAppService : ApplicationService, IThongTin_ThietBiAppService
    {
        private readonly IRepository<ThongTin_ThietBi, long> _repository;
        public ThongTin_ThietBiAppService(IRepository<ThongTin_ThietBi, long> initRepository)
        {
            _repository = initRepository;
        }      
        public async Task<PagedResultDto<ThongTin_ThietBiDto>> GetThongTin_ThietBis(GetThongTin_ThietBis input)
        {
            //Total Record
            var countQuery = _repository.GetAll()
                            .WhereIf(!string.IsNullOrEmpty(input.Filter), 
                                p => p.THIETBI.NAME.Contains(input.Filter));
            var totalRecord = countQuery.Count();
            //Record with filter & pager
            var result = _repository
                            .GetAll()
                            .WhereIf(!string.IsNullOrEmpty(input.Filter), p => p.THIETBI.NAME.Contains(input.Filter))
                            .OrderBy(p => p.THIETBI.NAME)                            
                            .PageBy(input).ToList();
            return new PagedResultDto<ThongTin_ThietBiDto>(
                totalRecord, 
                result.MapTo<List<ThongTin_ThietBiDto>>()
                );
        }
        public async Task<ThongTin_ThietBiDto> GetForEdit(GetThongTin_ThietBi input)
        {
            ThongTin_ThietBi nhomVT =  await _repository.GetAsync(input.Id);
            return nhomVT.MapTo<ThongTin_ThietBiDto>();
        }
        public void CreateThongTin_ThietBi(CreateOrEditThongTin_ThietBi input)
        {
            //We can use Logger, it's defined in ApplicationService class.
            //Logger.Info("Creating a nhom vattu for input: " + input);
            //Creating a new Task entity with given input's properties            
            var item = ObjectMapper.Map<ThongTin_ThietBi>(input);
            //Not use AutoMapper
            //ThongTin_ThietBi nhomVatTu = new ThongTin_ThietBi()
            //{
            //    TENNHOM = input.TENNHOM,
            //    MA_LOAITHUOC = input.MA_LOAITHUOC,
            //    MOTA = input.MOTA
            //};
            //Saving entity with standard Insert method of repositories.
            _repository.Insert(item);
        }
        public void UpdateThongTin_ThietBi(CreateOrEditThongTin_ThietBi input)
        {
            //We can use Logger, it's defined in ApplicationService base class.
            //Logger.Info("Update Nhom VatTu " + input);
            //Retrieving a task entity with given id using standard Get method of repositories.            
            var item = _repository.Get(input.Id);                  
            ObjectMapper.Map(input, item);
            //Not Use Auto Mapper
            //item.MA_LOAITHUOC = input.MA_LOAITHUOC;
            //item.MOTA = input.MOTA;
            //item.TENNHOM = input.TENNHOM; 
            //We even do not call Update method of the repository.
            //Because an application service method is a 'unit of work' scope as default.
            //ABP automatically saves all changes when a 'unit of work' scope ends (without any exception).
        }
        public void Delete(EntityDto<int> input)
        {
            _repository.Delete(input.Id);    
        }
        public List<ThongTin_ThietBiDto> GetThongTinQuanLyByIdThietBi(long idthietbi)
        {
            var result = _repository.GetAll().Where(x => x.IDTHIETBI == idthietbi).OrderBy(x => x.THONGTINQUANLY.SAPXEP).ToList();
            return result.MapTo<List<ThongTin_ThietBiDto>>();
        }

    }
}
