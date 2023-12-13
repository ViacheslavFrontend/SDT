using AutoMapper;
using BLL.DTO;
using BLL.Services.Interfaces;
using CLL.Security;
using CLL.Security.Indentity;
using DAL.Entities;
using DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Impl
{
    public class DishService : IDishService
    {
        private IUnitOfWork _unitOfWork;

        public DishService(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException(nameof(unitOfWork));
            }
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<DishDTO> GetDishesByMenu(int menuId)
        {
            var user = SecurityContext.GetUser();
            if(user.GetType() != typeof(Chief))
            {
                throw new MethodAccessException();
            }

            var menus = _unitOfWork.menusRepository.GetById(menuId);

            if(menus == null)
            {
                throw new NullReferenceException(nameof(menuId));
            }

            var dishes = _unitOfWork.dishesRepository
                .Find(dish => dish.MenuId == menuId);

            var mapper = new MapperConfiguration(
                cfg => cfg.CreateMap<Dish, DishDTO>()
                ).CreateMapper();
            var dishesDto = mapper.Map<IEnumerable<Dish>, List<DishDTO>>(dishes);

            return dishesDto;
        }
    }
}
