using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Features.CQRS.Queries.AboutQueries
{
    public class GetAboutByIdQuery
    {
        /*Dışarıdan bir id parametresi zorunlu kılar (Id = id;). Yani bu sorguyu kim tetiklemek isterse, 
         daha nesneyi üretirken hangi ID'yi aradığını belirtmek zorundadır.*/
        public GetAboutByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
