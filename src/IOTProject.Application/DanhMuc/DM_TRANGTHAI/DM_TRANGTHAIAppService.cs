using System.Linq;
using Abp.Domain.Repositories;
using Abp.Application.Services;
using IOTProject.DanhMuc;
using IOTProject.DanhMuc.Dtos;
using System.Collections.Generic;
using AutoMapper;
using Abp.Linq.Extensions;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System.Threading.Tasks;
using Abp.Runtime.Session;
using Abp.UI;

namespace IOTProject.DanhMuc
{
    public class DM_TRANGTHAIAppService : ApplicationService, IDM_TRANGTHAIAppService
    {
        private readonly IRepository<DM_TRANGTHAI, long> _repository;
        public DM_TRANGTHAIAppService(IRepository<DM_TRANGTHAI, long> initRepository)
        {
            _repository = initRepository;
        }      
        public async Task<PagedResultDto<DM_TRANGTHAIDto>> GetDM_TRANGTHAIs(GetDM_TRANGTHAIs input)
        {
            //Total Record
            var countQuery = _repository.GetAll()
                            .WhereIf(!string.IsNullOrEmpty(input.Filter), 
                                p => p.NAME.Contains(input.Filter));
            var totalRecord = countQuery.Count();
            //Record with filter & pager
            var result = _repository
                            .GetAll()
                            .WhereIf(!string.IsNullOrEmpty(input.Filter), p => p.NAME.Contains(input.Filter))
                            .OrderBy(p => p.NAME)                            
                            .PageBy(input).ToList();
            return new PagedResultDto<DM_TRANGTHAIDto>(
                totalRecord, 
                result.MapTo<List<DM_TRANGTHAIDto>>()
                );
        }
        public async Task<DM_TRANGTHAIDto> GetForEdit(GetDM_TRANGTHAI input)
        {
            DM_TRANGTHAI nhomVT =  await _repository.GetAsync(input.Id);
            return nhomVT.MapTo<DM_TRANGTHAIDto>();
        }
        public void CreateDM_TRANGTHAI(CreateOrEditDM_TRANGTHAI input)
        {
            //We can use Logger, it's defined in ApplicationService class.
            //Logger.Info("Creating a nhom vattu for input: " + input);
            //Creating a new Task entity with given input's properties            
            var item = ObjectMapper.Map<DM_TRANGTHAI>(input);
            //Not use AutoMapper
            //DM_TRANGTHAI nhomVatTu = new DM_TRANGTHAI()
            //{
            //    TENNHOM = input.TENNHOM,
            //    MA_LOAITHUOC = input.MA_LOAITHUOC,
            //    MOTA = input.MOTA
            //};
            //Saving entity with standard Insert method of repositories.
            _repository.Insert(item);
        }
        public void UpdateDM_TRANGTHAI(CreateOrEditDM_TRANGTHAI input)
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

    }
}
