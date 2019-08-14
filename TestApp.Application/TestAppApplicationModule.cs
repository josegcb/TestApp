using System.Reflection;
using Abp.Authorization;
using Abp.Authorization.Roles;
using Abp.Authorization.Users;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Modules;
using TestApp.Authorization.Roles;
using TestApp.Authorization.Users;
using TestApp.Dtos;
using TestApp.Models;
using TestApp.Roles.Dto;
using TestApp.Users.Dto;

namespace TestApp
{
    [DependsOn(typeof(TestAppCoreModule), typeof(AbpAutoMapperModule))]
    public class TestAppApplicationModule : AbpModule
    {
        public override void PreInitialize() {
            Configuration.Modules.AbpAutoMapper().Configurators.Add(mapper => {
                mapper.CreateMap<TipoNumeracion, TipoNumeracionDown>().ReverseMap();
                mapper.CreateMap<TipoNumeracion, TipoNumeracionPk>().ReverseMap();
                mapper.CreateMap<TipoNumeracion, TipoNumeracionUp>().ReverseMap();
                mapper.CreateMap<TipoNumeracion, TipoNumeracionDelete>().ReverseMap();

                mapper.CreateMap<Periodo, PeriodoDown>().ReverseMap();
                mapper.CreateMap<Periodo, PeriodoPk>().ReverseMap();
                mapper.CreateMap<Periodo, PeriodoDelete>().ReverseMap();
                mapper.CreateMap<Periodo, PeriodoUp>()
                    .ForMember(Up => Up.TenantConnectionString, conf => conf.MapFrom(T => T.Tenant.ConnectionString))
                    .ForMember(Up => Up.TenantName, conf => conf.MapFrom(T => T.Tenant.Name))
                    .ForMember(Up => Up.TipoNumeracionNombre, conf => conf.MapFrom(T => T.TipoNumeracion.Nombre))
                .ReverseMap();

                mapper.CreateMap<Cuenta, CuentaDown>().ReverseMap();
                mapper.CreateMap<Cuenta, CuentaPk>().ReverseMap();                
                mapper.CreateMap<Cuenta, CuentaDelete>().ReverseMap();
                mapper.CreateMap<Cuenta, CuentaActualizarNaturalezaDto>()
                    .ReverseMap()
                    .ForMember(T => T.Codigo, conf => conf.MapFrom(dto => dto.Id.ToString()))
                    .ForMember(T => T.Descripcion, conf => conf.MapFrom(dto => dto.Id.ToString()));
                mapper.CreateMap<Cuenta, CuentaUp>()
                    .ForMember(Up => Up.PeriodoNombre, conf => conf.MapFrom(T => T.Periodo.Nombre))
                    .ForMember(Up => Up.TenantNombre, conf => conf.MapFrom(T => T.Tenant.Name))
                .ReverseMap();

                mapper.CreateMap<Comprobante, ComprobanteDown>().ReverseMap();
                mapper.CreateMap<Comprobante, ComprobantePk>().ReverseMap();
                mapper.CreateMap<Comprobante, ComprobanteDelete>().ReverseMap();
                mapper.CreateMap<Comprobante, ComprobanteUp>()
                .ForMember(Up => Up.PeriodoNombre, conf => conf.MapFrom(T => T.Periodo.Nombre))                
                .ReverseMap();

                mapper.CreateMap<ComprobanteDetalleCuenta, ComprobanteDetalleCuentaDown>()
                //.ForMember(Down => Down.ComprobanteId, conf => conf.MapFrom(T => T.Comprobante.Id))
                     //Mapper.CreateMap<Source, Target>()
        //.ForMember(dest => dest.Value,
          //         opt => opt.MapFrom
            //       (src => src.Value1.StartsWith("A") ? src.Value1 : src.Value2));
                .ReverseMap();
                mapper.CreateMap<ComprobanteDetalleCuenta, ComprobanteDetalleCuentaPk>().ReverseMap();
                mapper.CreateMap<ComprobanteDetalleCuenta, ComprobanteDetalleCuentaDelete>().ReverseMap();
                mapper.CreateMap<ComprobanteDetalleCuenta, ComprobanteDetalleCuentaUp>()
                //.ForMember(Up => Up.CuentaId , conf => conf.MapFrom(T => T.Cuenta.Id))
                .ForMember(Up => Up.CuentaCodigo , conf => conf.MapFrom(T => T.Cuenta.Codigo))
                .ForMember(Up => Up.CuentaDescripcion , conf => conf.MapFrom(T => T.Cuenta.Descripcion))
                .ReverseMap();
            });
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            // TODO: Is there somewhere else to store these, with the dto classes
            Configuration.Modules.AbpAutoMapper().Configurators.Add(cfg =>
            {
                // Role and permission
                cfg.CreateMap<Permission, string>().ConvertUsing(r => r.Name);
                cfg.CreateMap<RolePermissionSetting, string>().ConvertUsing(r => r.Name);

                cfg.CreateMap<CreateRoleDto, Role>().ForMember(x => x.Permissions, opt => opt.Ignore());
                cfg.CreateMap<RoleDto, Role>().ForMember(x => x.Permissions, opt => opt.Ignore());
                
                cfg.CreateMap<UserDto, User>();
                cfg.CreateMap<UserDto, User>().ForMember(x => x.Roles, opt => opt.Ignore());

                cfg.CreateMap<CreateUserDto, User>();
                cfg.CreateMap<CreateUserDto, User>().ForMember(x => x.Roles, opt => opt.Ignore());
            });
        }
    }
}
