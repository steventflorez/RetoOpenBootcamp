using AutoMapper;
using FacturasApi.DTOs;
using FacturasApi.Models;

namespace FacturasApi.Utilidades
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() 
        {
            CreateMap<UsiarioCreacionDTO, Usuario>();


            CreateMap<LineInvoiceCreationDTO, LineInvoice>();


            CreateMap<EnterpriseCreationDTO, Enterprise>()
                .ForMember(ent => ent.Invoices, dto => 
                dto.MapFrom(campo => campo.Invoice.Select(id => new Invoice { Id = id} )));



            CreateMap<InvoiseCreationDTO, Invoice>()
                .ForMember(ent => ent.LineInvoices, dto =>
                dto.MapFrom(campo => campo.LineInvoice.Select(id => new LineInvoice { Id = id })));

        }
    }
}
