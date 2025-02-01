using OrderEats.Library.Application.Interfaces;
using OrderEats.Library.Application.Mapper;
using OrderEats.Library.Infrastructure.Repository;
using OrderEats.Library.Models.DTO;
using QRCoder;

namespace OrderEats.Main.API.Services
{
    public class TableService : ITableService
    {
        private readonly ITableRepository _repository;
        private readonly TableMapper _tableMapper;
        private readonly IConfiguration _config;

        public TableService(ITableRepository repository, TableMapper mapper, IConfiguration config)
        {
            _repository = repository;
            _tableMapper = mapper;
            _config = config;
        }

        public async Task<int> Add(TableDTO entity)
        {
            try
            {
                if (entity == null) return -1;
                var tableMapper = _tableMapper.Map(true, entity);
                tableMapper.QRCode = "";
                var idTable =  await _repository.Add(tableMapper);
                var QRCode = GenQrCode(idTable);
                tableMapper.QRCode = QRCode;
                var ck = await _repository.Update(idTable, tableMapper);
                if (ck) return tableMapper.Id;
                return -1;
            }catch
            {
                throw new ArgumentNullException(nameof(entity));
            }
            
        }

        public async Task<bool> AddMultiTable(List<TableDTO> tableDTOs)
        {
            try
            {
                if (tableDTOs.Count == 0) return false;
                var listTable = _tableMapper.MapList(tableDTOs);
                await _repository.AddMultiTable(listTable);
                foreach (var table in listTable)
                {
                    var QRCode = GenQrCode(table.Id);
                    table.QRCode = QRCode;
                    var updateResult = await _repository.Update(table.Id, table);
                    if (!updateResult) return false;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public string GenQrCode(int idTable)
        {
            string baseUrl = _config["BaseURL_Fe"];

            string tableInfo = $"{baseUrl}?TableId={idTable}";

            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            using (QRCodeData qrCodeData = qrGenerator.CreateQrCode(tableInfo, QRCodeGenerator.ECCLevel.Q))
            using (PngByteQRCode qrCode = new PngByteQRCode(qrCodeData))
            {
                byte[] qrCodeImage = qrCode.GetGraphic(20);
                var base64QRCode = Convert.ToBase64String(qrCodeImage);
                return base64QRCode;
            }
        } 

        public async Task<TableDTO> Get(int id)
        {
            var detail = await _repository.Get(id);
            var detailDTO = _tableMapper.Map(detail);
            return detailDTO;
        }

        public async Task<IEnumerable<TableDTO>> GetAll()
        {
            var listTable = await _repository.GetAll();
            return listTable.Select(table => _tableMapper.Map(table));
        }

        public async Task<bool> Update(int id, TableDTO entity)
        {
            var findTable = await _repository.Get(id);
            if (findTable == null) return false; 
            var tableMapper = _tableMapper.Map(entity);
            var ck = await _repository.Update(id, tableMapper);
            return ck;
        } 
    }
}
