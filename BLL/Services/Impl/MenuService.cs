using AutoMapper;
using BLL.DTO;
using BLL.Services.Interfaces;
using CLL.Security;
using CLL.Security.Indentity;
using DAL.Entities;
using DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Impl
{
    public class MenuService : IMenuService
    {
        private readonly IMenusRepository _menuRepository;

        public MenuService(IMenusRepository menuRepository)
        {
            if(menuRepository == null)
            {
                throw new ArgumentNullException(nameof(menuRepository));
            }
            _menuRepository = menuRepository;
        }

        public IEnumerable<MenuDTO> GetMenus()
        {
            var user = SecurityContext.GetUser();

            if(user.GetType() != typeof(Chief) && user.GetType() != typeof(Accountant))
            {
                throw new MethodAccessException();
            }

            var menus = _menuRepository.GetAll();

            var mapper = new MapperConfiguration(
                cfg => cfg.CreateMap<Menu, MenuDTO>()
                ).CreateMapper();
            var menusDto = mapper.Map<IEnumerable<Menu>, List<MenuDTO>>(menus);

            return menusDto;
        }
    }
}
