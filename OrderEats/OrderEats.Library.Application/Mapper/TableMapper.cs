using OrderEats.Library.Application.Interfaces;
using OrderEats.Library.Models.DTO;
using OrderEats.Library.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderEats.Library.Application.Mapper
{
    public class TableMapper : IMapper<TableDTO, Table>
    {
            public TableDTO Map(Table source)
            {
                if (source == null) return null;
                var tableDto = new TableDTO()
                {
                    Id = source.Id,
                    TableNumber = source.TableNumber,
                    IsOccupied = source.IsOccupied,
                    QRCode = source.QRCode,
                };
                return tableDto;
            }

            public Table Map(TableDTO destination)
            {
                if (destination == null) return null;
            var table = new Table()
            {
                Id = (int)destination.Id,
                TableNumber = destination.TableNumber,
                IsOccupied = destination.IsOccupied,
                QRCode = destination.QRCode,
            };
            return table;
            }

            public Table Map(bool isAddNew,  TableDTO destination)
        {
            if (destination == null) return null;
            var table = new Table()
            {
                TableNumber = destination.TableNumber,
                IsOccupied = destination.IsOccupied,
            };
            if (!isAddNew)
            {
                table.Id = destination.Id.Value;
            }
            return table;
        }

        public List<Table> MapList(IEnumerable<TableDTO> source)
            {
                if (source == null) return null;
                return source.Select(dto => Map(true, dto)).ToList();
            }
        }
    
}
