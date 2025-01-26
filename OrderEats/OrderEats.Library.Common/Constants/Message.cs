using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderEats.Library.Common.Constants
{
    public static class Message
    {
        #region CRUD 
        public const string Created = "Thêm mới thành công!";
        public const string Deleted = "Xóa thành công!";
        public const string Updated = "Cập nhật thành công!";
        #endregion

        #region Author
        public const string Forbidden = "Không có quyền truy cập hệ thống!";
        public const string InternalServerError = "Lỗi!!";
        public const string InvalidInput = "Dữ liệu đầu vào không hợp lệ";
        public const string Required = "Đây là trường bắt buộc!";
        #endregion

        #region Validate
        public const string StringLength = "Không được vượt quá {0} ký tự!";
        public const string DataEmpty = "Không có dữ liệu!";
        public const string FormatError = "Định dạng không hợp lệ!";
        public const string PasswordError = "Mật khẩu tối thiểu 6 kí tự!";
        #endregion
    }
}
