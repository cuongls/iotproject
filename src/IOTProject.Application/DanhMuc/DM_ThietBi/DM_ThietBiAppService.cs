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
using IOTProject.ThongTin;

namespace IOTProject.DanhMuc
{
    public class DM_ThietBiAppService : ApplicationService, IDM_ThietBiAppService
    {
        private readonly IRepository<DM_ThietBi, long> _repository;
        private readonly IThongTin_ThietBiAppService _thongTin_ThietBiService;
        public DM_ThietBiAppService(IRepository<DM_ThietBi, long> initRepository,
                                    IThongTin_ThietBiAppService thongTin_ThietBiService)
        {
            _repository = initRepository;
            _thongTin_ThietBiService = thongTin_ThietBiService;
        }      
        public async Task<PagedResultDto<DM_ThietBiDto>> GetDM_ThietBis(GetDM_ThietBis input)
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
            return new PagedResultDto<DM_ThietBiDto>(
                totalRecord, 
                result.MapTo<List<DM_ThietBiDto>>()
                );
        }
        public async Task<DM_ThietBiDto> GetForEdit(GetDM_ThietBi input)
        {
            DM_ThietBi nhomVT =  await _repository.GetAsync(input.Id);
            return nhomVT.MapTo<DM_ThietBiDto>();
        }
        public void CreateDM_ThietBi(CreateOrEditDM_ThietBi input)
        {
            //We can use Logger, it's defined in ApplicationService class.
            //Logger.Info("Creating a nhom vattu for input: " + input);
            //Creating a new Task entity with given input's properties            
            var item = ObjectMapper.Map<DM_ThietBi>(input);
            //Not use AutoMapper
            //DM_ThietBi nhomVatTu = new DM_ThietBi()
            //{
            //    TENNHOM = input.TENNHOM,
            //    MA_LOAITHUOC = input.MA_LOAITHUOC,
            //    MOTA = input.MOTA
            //};
            //Saving entity with standard Insert method of repositories.
            _repository.Insert(item);
        }
        public void UpdateDM_ThietBi(CreateOrEditDM_ThietBi input)
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
        public GiamSatThietBi2Cot GetListGiamSatThietBi(GiamSatInput input)
        {
            var lsThietBi = _repository.GetAll()
                                       .WhereIf(input.iddonvi != 0, x => x.TRAM.IDDONVI == input.iddonvi)
                                       .WhereIf(input.idtram != 0, x => x.IDTRAM == input.idtram)
                                       .WhereIf(input.idthietbi != 0, x => x.Id == input.idtram)
                                       .ToList().MapTo<List<DM_ThietBiDto>>();
            GiamSatThietBi2Cot result = new GiamSatThietBi2Cot();
            List <GiamSatThietBi> cot1 = new List<GiamSatThietBi>();
            List<GiamSatThietBi> cot2 = new List<GiamSatThietBi>();
            if(lsThietBi.Count > 0)
            {
                for (var i = 0; i < lsThietBi.Count; i++)
                {
                    
                    if (i % 2 == 0)
                    {
                        GiamSatThietBi giamsat = new GiamSatThietBi();
                        giamsat.thietbi = lsThietBi[i];
                        giamsat.lsThongTin = _thongTin_ThietBiService.GetThongTinQuanLyByIdThietBi(lsThietBi[i].Id);
                        cot2.Add(giamsat);
                    }
                    else
                    {
                        GiamSatThietBi giamsat = new GiamSatThietBi();
                        giamsat.thietbi = lsThietBi[i];
                        giamsat.lsThongTin = _thongTin_ThietBiService.GetThongTinQuanLyByIdThietBi(lsThietBi[i].Id);
                        cot1.Add(giamsat);
                    }
                }
            }
            result.cot1 = cot1;
            result.cot2 = cot2;
            return result;
        }
    }
}
