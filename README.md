# Tìm hiểu về ASP.NET Core MVC

## 1. Cấu trúc thư mục dự án
Cấu trúc cơ bản của một dự án .NET MVC bao gồm:
* **Controllers/**: Chứa các lớp C# xử lý yêu cầu từ người dùng, tương tác với Model và chọn View để hiển thị.
* **Models/**: Chứa các lớp định nghĩa dữ liệu và logic nghiệp vụ của ứng dụng.
* **Views/**: Chứa các tệp giao diện (.cshtml). Đây là nơi hiển thị dữ liệu cho người dùng.
* **wwwroot/**: Thư mục chứa các tài nguyên tĩnh như CSS, JavaScript, hình ảnh và thư viện phía client (Bootstrap, jQuery).
* **Program.cs**: Điểm khởi đầu của ứng dụng, nơi cấu hình các dịch vụ (Services) và các đường ống xử lý yêu cầu (Middleware/Pipeline).
* **appsettings.json**: Tệp cấu hình ứng dụng (như chuỗi kết nối cơ sở dữ liệu, các biến môi trường).



## 2. Định tuyến (Routing) trong .Net MVC
Routing là cơ chế ánh ánh các URL từ trình duyệt đến các hành động (Actions) tương ứng trong Controller.
* **Định tuyến mặc định (Conventional Routing)**: Được cấu hình trong `Program.cs`. 
    * Cấu trúc mặc định: `{controller=Home}/{action=Index}/{id?}`.
    * Ví dụ: URL `/Product/Details/5` sẽ gọi đến `ProductController`, phương thức `Details` với tham số `id = 5`.
* **Định tuyến thuộc tính (Attribute Routing)**: Sử dụng các thuộc tính như `[Route("ten-duong-dan")]` ngay trên đầu Controller hoặc Action để tùy chỉnh URL linh hoạt hơn.

## 3. Controller và View
* **Controller**: Là lớp kế thừa từ `Microsoft.AspNetCore.Mvc.Controller`. Mỗi phương thức public trong Controller được gọi là một **Action**, thường trả về một `IActionResult` (phổ biến nhất là `View()`).
* **View**: Sử dụng cú pháp **Razor** (kết hợp HTML và C#). View thường nằm trong thư mục `Views/[TênController]/[TênAction].cshtml`.
* **Truyền dữ liệu**: Controller có thể truyền dữ liệu sang View thông qua `ViewBag`, `ViewData`, `TempData` hoặc sử dụng `Strongly Typed Model`.

# Bài Thực Hành Số 4: ViewBag, Models và Form Handling trong ASP.NET Core MVC

Dự án này là bài thực hành tìm hiểu về cách truyền nhận dữ liệu giữa Controller và View, làm việc với Model và cấu hình giao diện Layout.

## 1. Nội dung thực hành

### Phần 1: ViewBag và Gửi dữ liệu cơ bản
* **Mục tiêu:** Hiểu cách gửi dữ liệu từ View lên Controller và ngược lại.
* **Chức năng:**
    * Người dùng nhập "Họ tên" từ View.
    * Controller nhận dữ liệu qua tham số hàm.
    * Controller xử lý chuỗi "Xin chào + [Họ tên]" và gửi lại View bằng `ViewBag`.

### Phần 2: Làm việc với Model (Student)
* **Mục tiêu:** Sử dụng Class để đóng gói dữ liệu.
* **Model:** `Student`
    * `StudentCode`: Mã sinh viên.
    * `FullName`: Họ và tên.
* **Chức năng:**
    * Tạo Form nhập liệu có liên kết (binding) với Model `Student`.
    * Controller nhận cả đối tượng `Student` từ Form gửi lên.

### Phần 3: Cấu hình Layout
* **Mục tiêu:** Tạo điều hướng (Navigation) thuận tiện.
* **Thực hiện:**
    * Sửa file `_Layout.cshtml`.
    * Thêm menu dẫn tới chức năng quản lý sinh viên (`StudentController`).

## 2. Hướng dẫn cài đặt và chạy

1.  Clone dự án về máy:
    ```bash
    git clone <đường-dẫn-repo-của-bạn>
    ```
2.  Mở dự án bằng Visual Studio hoặc VS Code.
3.  Chạy ứng dụng (F5 hoặc `dotnet run`).
4.  Truy cập chức năng tại menu hoặc đường dẫn:
    * `https://localhost:<port>/Student/Create`

## 3. Cấu trúc Code chính

**Student Model:**
```csharp
public class Student
{
    public string StudentCode { get; set; }
    public string FullName { get; set; }
}

