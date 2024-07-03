using Infrastructure.Constans;
using Infrastructure.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PagedList;
using SWP.Infrastrcuture.Entities;
using SWPApi.Application.Account.Commands;
using SWPApi.Application.Account.Responses;

namespace SWPApi.Application.Account.Handlers
{
    public class GetAllUserHandler : IRequestHandler<GetAllUserCommand, GetAllUserResponse>
    {
        UserManager<AppUser> _userManager;
        IHttpContextAccessor _httpContextAccessor;
         RoleManager<IdentityRole> _roleManager;

        public GetAllUserHandler(UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _roleManager = roleManager;
        }

        public async Task<GetAllUserResponse> Handle(GetAllUserCommand request, CancellationToken cancellationToken)
        {
            var response = new GetAllUserResponse();
            var user = _httpContextAccessor.HttpContext?.User;

            if (user == null)
            {
                response.IsSuccess = false;
                response.ErrorMessage = "Không thể xác định người dùng hiện tại.";
                return response;
            }

            var currentUser = await _userManager.GetUserAsync(user);
            if (currentUser == null)
            {
                response.IsSuccess = false;
                response.ErrorMessage = "Không thể tìm thấy người dùng hiện tại.";
                return response;
            }

            var roles = await _userManager.GetRolesAsync(currentUser);

            IQueryable<AppUser> usersQuery = _userManager.Users;

            if (roles.Contains(UserRolesConstant.Staff))
            {
                var customerRole = await _roleManager.FindByNameAsync(UserRolesConstant.Customer);
                if (customerRole != null)
                {
                    var customerUserIds = await _userManager.GetUsersInRoleAsync(UserRolesConstant.Customer);
                    usersQuery = usersQuery.Where(u => customerUserIds.Select(cu => cu.Id).Contains(u.Id));
                }
            }

            var usersList = await usersQuery
                .Select(u => new GetAllUserResponse.User
                {
                    Id = u.Id,
                    Email = u.Email,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Address = u.Address,
                    PhoneNumber = u.PhoneNumber,
                    LockoutEnabled = u.LockoutEnabled
                })
                .ToListAsync(cancellationToken);

            var pagedUsers = usersList.ToPagedList(request.pageNumber, request.pageSize);

            response.Data = pagedUsers;
            response.IsSuccess = true;

            return response;
        }
    }
}
