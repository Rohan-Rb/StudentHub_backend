using student_hub_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_hub_backend.Services
{
    public class RoleService: IRoleService
    {
        private RoleContext _context;
        public RoleService(RoleContext context)
        {
            _context = context;
        }

        public List<Roles> GetRolesList()
        {
            List<Roles> roleList;
            try
            {
                roleList = _context.Set<Roles>().ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return roleList;
        }

        public Roles GetRoleDetailsById(int roleId)
        {
            Roles roles;
            try
            {
                roles = _context.Find<Roles>(roleId);
            }
            catch (Exception)
            {
                throw;
            }
            return roles;
        }

        public ResponseModel SaveRole(Roles roleModel)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                Roles _temp = GetRoleDetailsById(roleModel.RoleID);
                if (_temp != null)
                {
                    _temp.RoleTitle = roleModel.RoleTitle;
                  
                    _context.Update<Roles>(_temp);
                    model.Messsage = "role Update Successfully";
                }
                else
                {
                    _context.Add<Roles>(roleModel);
                    model.Messsage = "Roles Inserted Successfully";
                }
                _context.SaveChanges();
                model.IsSuccess = true;
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Messsage = "Error : " + ex.Message;
            }
            return model;
        }

        public ResponseModel DeleteRole(int roleId)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                Roles _temp = GetRoleDetailsById(roleId);
                if (_temp != null)
                {
                    _context.Remove<Roles>(_temp);
                    _context.SaveChanges();
                    model.IsSuccess = true;
                    model.Messsage = "role Deleted Successfully";
                }
                else
                {
                    model.IsSuccess = false;
                    model.Messsage = "role Not Found";
                }
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Messsage = "Error : " + ex.Message;
            }
            return model;
        }
    }
}
